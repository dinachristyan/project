using System.Data;
using MySql.Data.MySqlClient;

public class DbManager
{
    private readonly string _connectionString;

    private readonly MySqlConnection _connection;

    public DbManager(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        _connection = new MySqlConnection(_connectionString);
    }

    public List<Mahasiswa> GetAllMahasiswas()
    {
        List<Mahasiswa> mahasiswasList = new List<Mahasiswa>();
        try
        {
            using(MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM ms_mahasiswa";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Mahasiswa mahasiswa = new Mahasiswa
                        {
                            mhs_nim = reader["Mhs_nim"].ToString(),
                            mhs_nama = reader["Mhs_nama"].ToString()
                        };
                        mahasiswasList.Add(mahasiswa);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return mahasiswasList;
    }

    //create
    public int CreateMahasiswa(Mahasiswa mahasiswa)
    {
        using (MySqlConnection connection = _connection)
        {
            string query = "INSERT INTO ms_mahasiswa (mhs_nim, mhs_nama) VALUES (@Mhs_nim, @Mhs_nama)";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Mhs_nim", mahasiswa.mhs_nim);
                command.Parameters.AddWithValue("@Mhs_nama", mahasiswa.mhs_nama);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }


    //update
    public int UpdateMahasiswa(int id, Mahasiswa mahasiswa)
    {
        using (MySqlConnection connection = _connection)
        {
            string query = "UPDATE ms_mahasiswa SET mhs_nama = @Mhs_nama WHERE mhs_nim = @Mhs_nim";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Mhs_nim", mahasiswa.mhs_nim);
                command.Parameters.AddWithValue("@Mhs_nama", mahasiswa.mhs_nama);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }


    //delete
    public int DeleteMahasiswa(int id)
    {
        using (MySqlConnection connection = _connection)
        {
            string query = "DELETE FROM ms_mahasiswa WHERE mhs_nim = @Mhs_nim";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Mhs_nim", id);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }


    public Mahasiswa GetMahasiswaById(int id)
    {
        Mahasiswa mahasiswa = null;
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM ms_mahasiswa WHERE mhs_nim = @Mhs_nim";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Mhs_nim", id);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        mahasiswa = new Mahasiswa
                        {
                            mhs_nim = reader["Mhs_nim"].ToString(),
                            mhs_nama = reader["Mhs_nama"].ToString()
                        };
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return mahasiswa;
    }




    //TRAINER
    public List<Trainer> GetAllTrainers()
    {
        List<Trainer> trainersList = new List<Trainer>();
        try
        {
            using(MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM trainer";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Trainer trainer = new Trainer
                        {
                            nip = reader["Nip"].ToString(),
                            nama = reader["Nama"].ToString(),
                            telp = reader["Telp"].ToString(),
                            email = reader["Email"].ToString()

                        };
                        trainersList.Add(trainer);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return trainersList;
    }

    //create
    public int CreateTrainer(Trainer trainer)
    {
        using (MySqlConnection connection = _connection)
        {
            string query = "INSERT INTO trainer (nip, nama, telp, email) VALUES (@Nip, @Nama, @Telp, @Email)";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nip", trainer.nip);
                command.Parameters.AddWithValue("@Nama", trainer.nama);
                command.Parameters.AddWithValue("@Telp", trainer.telp);
                command.Parameters.AddWithValue("@Email", trainer.email);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }


    //update
    public int UpdateTrainer(int id, Trainer trainer)
    {
        using (MySqlConnection connection = _connection)
        {
            string query = "UPDATE trainer SET nama = @Nama, telp = @Telp, email= @Email WHERE nip = @Nip";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nip", trainer.nip);
                command.Parameters.AddWithValue("@Nama", trainer.nama);
                command.Parameters.AddWithValue("@Telp", trainer.telp);
                command.Parameters.AddWithValue("@Email", trainer.email);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }


    //delete
    public int DeleteTrainer(int id)
    {
        using (MySqlConnection connection = _connection)
        {
            string query = "DELETE FROM trainer WHERE nip = @Nip";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nip", id);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }


    //GetByID
    public Trainer GetTrainerById(int id)
    {
        Trainer trainer = null;
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM trainer WHERE nip = @Nip";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nip", id);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        trainer = new Trainer
                        {
                            nip = reader["Nip"].ToString(),
                            nama = reader["Nama"].ToString(),
                            telp = reader["Telp"].ToString(),
                            email = reader["Email"].ToString()

                        };
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return trainer;
    }


}
