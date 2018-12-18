using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace DataAccessLibrary
{
    public static class DataAccess
    {
        /// <summary>
        /// Initializes the SQLite database, with an Admin Table of 6 Admins rows, and a Course Table, a Student Table, A Grade Table, A Professor Table
        /// </summary>
        public static void InitializeDatabase()
        {

            //Initializes schoolDB.db with all the tables
            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Admin (Admin_ID INTEGER PRIMARY KEY, " +
                                "Password TEXT NOT NULL," +
                                "First_Name TEXT NOT NULL," +
                                "Last_Name TEXT NOT NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();

                tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Course (Course_ID TEXT PRIMARY KEY, " +
                                "Course_Name TEXT NOT NULL, " +
                                "Professor_ID INTEGER NOT NULL, " +
                                "FOREIGN KEY (Professor_ID) REFERENCES Professor (Professor_ID)" +
                                    "ON DELETE SET NULL ON UPDATE NO ACTION" +
                                ")";

                createTable.CommandText = tableCommand;
                createTable.ExecuteReader();

                tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Student (Student_ID INTEGER PRIMARY KEY, " +
                                "Password TEXT NOT NULL," +
                                "First_Name TEXT NOT NULL," +
                                "Last_Name TEXT NOT NULL)";

                createTable.CommandText = tableCommand;
                createTable.ExecuteReader();

                tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Professor (Professor_ID INTEGER PRIMARY KEY, " +
                                "Password TEXT NOT NULL," +
                                "First_Name TEXT NOT NULL," +
                                "Last_Name TEXT NOT NULL)";

                createTable.CommandText = tableCommand;
                createTable.ExecuteReader();

                tableCommand = "CREATE TABLE IF NOT " +
                   "EXISTS Grade (Course_ID TEXT NOT NULL, " +
                               "Student_ID TEXT NOT NULL, " +
                               "GradePoint INTEGER, " +
                               "PRIMARY KEY (Course_ID, Student_ID), " +
                               "FOREIGN KEY (Course_ID) REFERENCES Course (Course_ID)" +
                                    "ON DELETE SET NULL ON UPDATE NO ACTION, " +
                               "FOREIGN KEY (Student_ID) REFERENCES Student (Student_ID)" +
                                    "ON DELETE SET NULL ON UPDATE NO ACTION" +
                               ")";

                createTable.CommandText = tableCommand;
                createTable.ExecuteReader();
            }

            //Create 6 Admins to start the database with
            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT OR IGNORE INTO Admin (Admin_ID, Password, First_Name, Last_Name) " +
                                                        "VALUES (90000, 'j123', 'Justen', 'Hitchcock'), " +
                                                                "(90001, 'c123', 'Carlos', 'Fletes'), " +
                                                                "(90002, 'm123', 'Matthew', 'Punsalan'), " +
                                                                "(90003, 'r123', 'Roque', 'Figueroa'), " +
                                                                "(90004, 'x123', 'Xuong', 'Truong'), " +
                                                                "(90005, 'a123', 'Andrew', 'Amack')";

                insertCommand.ExecuteReader();

                db.Close();
            }
        }

        ///// <summary>
        ///// Inserts data into the SQLite database.
        ///// </summary>
        ///// <param name="inputText"></param>
        //public static void AddData(string inputText)
        //{
        //    using (SqliteConnection db =
        //        new SqliteConnection("Filename=schoolDB.db"))
        //    {
        //        db.Open();

        //        SqliteCommand insertCommand = new SqliteCommand();
        //        insertCommand.Connection = db;

        //        // Use parameterized query to prevent SQL injection attacks
        //        insertCommand.CommandText = "INSERT INTO MyTable VALUES (NULL, @Entry);";
        //        insertCommand.Parameters.AddWithValue("@Entry", inputText);

        //        insertCommand.ExecuteReader();

        //        db.Close();
        //    }

        //}

        ///// <summary>
        ///// Gets rows of data from a SQLite database.
        ///// </summary>
        ///// <returns></returns>
        public static List<string> GetData(string table, string column)
        {
            List<string> entries = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand($"SELECT {column} FROM {table}", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }

                db.Close();
            }

            return entries;
        }
    }
}