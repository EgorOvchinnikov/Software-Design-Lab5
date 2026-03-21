using MySql.Data.MySqlClient;

public class Program
{
    static void Main(string[] args)
    {
        DateTime startTime = DateTime.Now;
        string parameters = args[0] + " " + args[1] + " " + args[2];
        string result = "";

        if (args[1] == "+")
            result = (Convert.ToInt32(args[0]) + Convert.ToInt32(args[2])).ToString();
        if (args[1] == "-")
            result = (Convert.ToInt32(args[0]) - Convert.ToInt32(args[2])).ToString();
        if (args[1] == "*")
            result = (Convert.ToInt32(args[0]) * Convert.ToInt32(args[2])).ToString();
        Console.WriteLine(result);

        DateTime endTime = DateTime.Now;

        string _connectionString = "Server=localhost;Database=pluginsapp;Uid=root;Pwd=;";
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            var query = $@"INSERT INTO calculator_logs (start_time, end_time, params, result) 
                            VALUES (@startTime, @endTime, @parameters, @result)";

            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@startTime", startTime);
                cmd.Parameters.AddWithValue("@endTime", endTime);
                cmd.Parameters.AddWithValue("@parameters", parameters);
                cmd.Parameters.AddWithValue("@result", result);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }

        Console.ReadKey();
    }
}
