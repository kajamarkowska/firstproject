using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace PersonDatabase.Model
{
    public class ReportGenerator
    {
        private string filename;
        public ReportGenerator(string filename)
        {
            this.filename = filename;
        }

        public string Generate(string sqlFileName,string htmlFileName)
        {
            string sql = File.ReadAllText(sqlFileName);
            string html = File.ReadAllText(htmlFileName);
           

            using (SQLiteConnection connect = new SQLiteConnection("Data Source=" + filename))
            {
                connect.Open();
                using (SQLiteCommand command = connect.CreateCommand())
                {
                    command.CommandText = sql ;
                    SQLiteDataReader reader = command.ExecuteReader();
                    string header = "";
                    for (int i = 0; i<reader.FieldCount; i++)
                    {
                        header += "<th>";
                        header += reader.GetName(i);
                        header += "</th>";
                    }
                    html = html.Replace("#HEADER", header);
                    string content = "";
                    while (reader.Read()) 
                    {
                        content += "<tr>";
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            content += "<td>";
                            content += reader.GetValue(i);
                            content += "</td>";
                            
                        }
                        content += "</tr>";
                    }
                    html = html.Replace("#CONTENT", content);
                   
                }

            }
           
            return html;
        }
    }

    
}

