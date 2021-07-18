using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConsoleApp2
{
    class Main_menu
    {
        public void Vie()
        {
            var b = new Database();
            Console.Clear(); //очистка экрана 
            int m = 1;
            while (m == 1)
            {
                Console.WriteLine("Введите нужный пункт с клавиатуры");
                Console.WriteLine("1-Показать базу данных");
                Console.WriteLine("2-Добавить новую запись");
                Console.WriteLine("3-Редактировать запись");
                Console.WriteLine("4-Удалить записть");
                Console.WriteLine("5-Показать ближайших именниников");
                Console.WriteLine("6-Выход");
                int n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        {
                            
                            Console.ReadLine();
                            Console.Clear(); //очистка экрана 
                            b.read();
                            break;
                        }
                    case 2:
                        {
                            
                            Console.ReadLine();
                            Console.Clear(); //очистка экрана 
                            b.create();
                            break;
                        }
                    case 3:
                        {
                           
                            Console.ReadLine();
                            Console.Clear(); //очистка экрана 
                            b.update();
                            break;
                        }
                    case 4:
                        {
                            
                            Console.ReadLine();
                            Console.Clear(); //очистка экрана
                            b.delete();
                            break;
                        }
                    case 5:
                        {
                           
                            Console.ReadLine();
                            b.orderBy();
                            Console.Clear(); //очистка экрана
                            break;
                        }
                    case 6:
                        {
                           
                            m++;
                            break;
                        }
                }
            }
        }
    }

    class Database
    {
        public async void read()
        {
            DB db = new DB();
            DataTable table = new DataTable();
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            Console.WriteLine("Работа функции read");

            MySqlCommand command = new MySqlCommand("SELECT * FROM `bithday`", db.getConnection());

            adapter.SelectCommand = command;

            adapter.Fill(table);

            MySqlDataReader reader;
            Console.WriteLine("Id | Name | day | mouth | class | ");
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Data data = new Data((int)reader["id"] , (string)reader["Name"] , (int)reader["number"] , (int)reader["mouth"] , (string)reader["class"]);
                    Console.WriteLine(data.Id + " | " + data.Name + " | " + data.number + " | " + data.mouth + " | " + data.clas + " | ");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            Console.ReadLine();

            Console.Clear(); //очистка экрана
        }

        public void create()
        {
            DB db = new DB();

            Console.WriteLine("Добавление новой записи");
            Console.WriteLine("ФИО");
            string name = Console.ReadLine();
            //добавить проверку 

            Console.WriteLine("День");
            int number = Convert.ToInt32(Console.ReadLine());
            //добавить проверку 
                
            Console.WriteLine("Месяц");
            int mouth = Convert.ToInt32(Console.ReadLine());
            // добавить проверку

            Console.WriteLine("Связь");
            string cl = Console.ReadLine();
            Console.WriteLine("Добавить данные?");
            Console.WriteLine("1-Да");
            Console.WriteLine("2-Нет.Выход в главное меню");
            int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    {
                        MySqlCommand command = new MySqlCommand("INSERT INTO `bithday` (`Name`, `Number`, `mouth`, `Class`) VALUES (@name, @day, @mouth, @class);", db.getConnection());
                        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                        command.Parameters.Add("@day", MySqlDbType.Int32).Value = number;
                        command.Parameters.Add("@mouth", MySqlDbType.Int32).Value = mouth;
                        command.Parameters.Add("@class", MySqlDbType.VarChar).Value = cl;
                        db.openConnection();
                            if(command.ExecuteNonQuery() == 1)
                                Console.WriteLine("Запись успешно добавлена");
                            else
                                Console.WriteLine("Не удалось добавить запись");
                        db.closeConnection();
                        Console.WriteLine("Нажмите Enter");
                        Console.ReadLine();
                        Console.Clear(); //очистка экрана
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Отмена");
                        Console.ReadLine();
                        Console.Clear(); //очистка экрана
                        break;
                    }
            }

        }

        public  void update()
        {
            Console.Clear(); //очистка экрана 
            Console.WriteLine("Редактирование новой записи");
            Console.WriteLine("Введите номер записи");
            int id = Convert.ToInt32(Console.ReadLine());
            DB db = new DB();
            db.openConnection();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `bithday` WHERE Id = @id", db.getConnection());

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            adapter.SelectCommand = command;


            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                Console.WriteLine("Данные записи");
                MySqlCommand command2 = new MySqlCommand($"SELECT * FROM `bithday` where Id = {id}", db.getConnection());

                adapter.SelectCommand = command;

                adapter.Fill(table);

                MySqlDataReader reader;
                Console.WriteLine("Id | Name | day | mouth | class | ");
                try
                {
                    reader = command2.ExecuteReader();
                    while (reader.Read())
                    {
                        Data data = new Data((int)reader["id"], (string)reader["Name"], (int)reader["number"], (int)reader["mouth"], (string)reader["class"]);
                        Console.WriteLine(data.Id + " | " + data.Name + " | " + data.number + " | " + data.mouth + " | " + data.clas + " | ");
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: \r\n{0}", ex.ToString());
                }
            }
               
            else
            {
                Console.WriteLine("Пользователя с данным ID не существует.Для продолжения нажмите Enter");
                Console.ReadLine();
                Console.Clear(); //очистка экрана 
                return;
            }

            Console.WriteLine("Выберите пункт меню");
            Console.WriteLine("1-Отменить редактирование");
            Console.WriteLine("2-Продолжить редактирование");
            int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    {
                        Console.Write("Case1");
                        Console.ReadLine();
                        Console.Clear(); //очистка экрана 
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Выберите пункт меню");
                        Console.WriteLine("1-Редактировать Id");
                        Console.WriteLine("2-Редактировать имя");
                        Console.WriteLine("3-Редактировать день");
                        Console.WriteLine("4-Редактировать месяц");
                        Console.WriteLine("5-Редактировать связь");
                        Console.WriteLine("6-Выход");
                        int m = Convert.ToInt32(Console.ReadLine());
                        switch (m)
                        {
                            case 1:
                                {
                                    Console.WriteLine("Редактирование Id");
                                    Console.WriteLine("Введите новый Id");
                                    int Newid = Convert.ToInt32(Console.ReadLine());
                                    MySqlCommand command1 = new MySqlCommand($"UPDATE `bithday` SET `Id` = {Newid} WHERE `bithday`.`Id` = {id}", db.getConnection());
                                    adapter.SelectCommand = command1;
                                    adapter.Fill(table);
                                    if (table.Rows.Count > 0)
                                        Console.WriteLine("Yes");
                                    else
                                    {
                                        Console.Clear(); //очистка экрана 
                                        return;
                                    }
                                    Console.ReadLine();
                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine("Редактирование имени");
                                    Console.WriteLine("Введите новое именя");
                                    string NewName = Console.ReadLine();
                                    MySqlCommand command1 = new MySqlCommand($"UPDATE `bithday` SET `Name` = '{NewName}' WHERE `bithday`.`Id` = {id}", db.getConnection());
                                    adapter.SelectCommand = command1;

                                    adapter.Fill(table);

                                    if (table.Rows.Count > 0)
                                        Console.WriteLine("Yes");
                                    else
                                    {
                                        Console.Clear(); //очистка экрана 
                                        return;
                                    }
                                    Console.ReadLine();
                                    break;
                                }
                            case 3:
                                {
                                    Console.WriteLine("Редактирование дня");
                                    Console.WriteLine("Введите день");
                                    int day = Convert.ToInt32(Console.ReadLine());
                                    MySqlCommand command1 = new MySqlCommand($"UPDATE `bithday` SET `number` = {day} WHERE `bithday`.`Id` = {id}", db.getConnection());
                                    adapter.SelectCommand = command1;

                                    adapter.Fill(table);

                                    if (table.Rows.Count > 0)
                                        Console.WriteLine("Yes");
                                    else
                                    {
                                        Console.Clear(); //очистка экрана 
                                        return;
                                    }
                                    Console.ReadLine();
                                    break;
                                }
                            case 4:
                                {
                                    Console.WriteLine("Редактирование месяца");
                                    Console.WriteLine("Введите день");
                                    Console.WriteLine(id);
                                    int mouth = Convert.ToInt32(Console.ReadLine());
                                    MySqlCommand command1 = new MySqlCommand($"UPDATE `bithday` SET `mouth` = {mouth} WHERE `bithday`.`Id` = {id}", db.getConnection());
                                    command.Parameters.Add("@mouth", MySqlDbType.Int32).Value = mouth;
                                    adapter.SelectCommand = command1;

                                    adapter.Fill(table);

                                    if (table.Rows.Count > 0)
                                        Console.WriteLine("Yes");
                                    else
                                    {
                                        Console.Clear(); //очистка экрана 
                                        return;
                                    }
                                    Console.ReadLine();
                                    break;
                                }
                            case 5:
                                {
                                    Console.WriteLine("Редактирование связи");
                                    Console.WriteLine("Введите новую связь");
                                    Console.WriteLine(id);
                                    string class1 = Console.ReadLine();
                                    MySqlCommand command1 = new MySqlCommand($"UPDATE `bithday` SET `class` = '{class1}' WHERE `bithday`.`Id` = {id}", db.getConnection());
                                    adapter.SelectCommand = command1;

                                    adapter.Fill(table);

                                    if (table.Rows.Count > 0)
                                        Console.WriteLine("Yes");
                                    else
                                    {
                                        Console.Clear(); //очистка экрана 
                                        return;
                                    }
                                    Console.ReadLine();
                                    break;
                                }
                            case 6:
                                {
                                    break;
                                }
                        }
                        Console.Clear(); //очистка экрана 
                        break;
                    }
            }
        }

        public void delete()
        {
            Console.Clear(); //очистка экрана 
            Console.WriteLine("Удаление");
            Console.WriteLine("Введите номер записи");
            int id = Convert.ToInt32(Console.ReadLine());
            DB db = new DB();
            db.openConnection();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `bithday` WHERE Id = @id", db.getConnection());

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
                Console.WriteLine("пользователь с данным ID существует");
            else
            {
                Console.WriteLine("Пользователя с данным ID не существует.Для продолжения нажмите Enter");
                Console.ReadLine();
                Console.Clear(); //очистка экрана 
                return;
            }
            Console.WriteLine(table);
            Console.WriteLine("Данные записи");
            MySqlCommand command2 = new MySqlCommand($"SELECT * FROM `bithday` where Id = {id}", db.getConnection());

            adapter.SelectCommand = command;

            adapter.Fill(table);

            MySqlDataReader reader;
            Console.WriteLine("Id | Name | day | mouth | class | ");
            try
            {
                reader = command2.ExecuteReader();
                while (reader.Read())
                {
                    Data data = new Data((int)reader["id"], (string)reader["Name"], (int)reader["number"], (int)reader["mouth"], (string)reader["class"]);
                    Console.WriteLine(data.Id + " | " + data.Name + " | " + data.number + " | " + data.mouth + " | " + data.clas + " | ");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            Console.WriteLine("Выберите пункт меню");
            Console.WriteLine("1-Отменить Удаление");
            Console.WriteLine("2-Продолжить удаление");
            int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    {
                        Console.Write("Отмена delete нажмите Enter");
                        Console.ReadLine();
                        Console.Clear(); //очистка экрана 
                        break;
                    }
                case 2:
                    {
                        MySqlCommand command1 = new MySqlCommand("DELETE FROM `bithday` WHERE `bithday`.`Id` = @id", db.getConnection());
                        command1.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                        adapter.SelectCommand = command1;

                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                            Console.Write("Запись удалена нажмите Enter");
                        else
                        {
                            Console.Clear(); //очистка экрана 
                            return;
                        }
                        Console.ReadLine();
                        Console.Clear(); //очистка экрана 
                        break;
                    }
            }
            db.closeConnection();
        }

        public void orderBy()
        {
            Console.Clear(); //очистка экрана
            DB db = new DB();
            DataTable table = new DataTable();
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            Console.WriteLine("Вывод ");
            string date = DateTime.Now.ToShortDateString();
            int nowMouth = Convert.ToInt32($"{date[3]}{date[4]}");
            MySqlCommand command = new MySqlCommand($"SELECT * FROM `bithday` where mouth = {nowMouth}", db.getConnection());

            adapter.SelectCommand = command;

            adapter.Fill(table);

            MySqlDataReader reader;
            Console.WriteLine("Id | Name | day | mouth | class | ");
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Data data = new Data((int)reader["id"], (string)reader["Name"], (int)reader["number"], (int)reader["mouth"], (string)reader["class"]);
                    Console.WriteLine(data.Id + " | " + data.Name + " | " + data.number + " | " + data.mouth + " | " + data.clas + " | ");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            Console.ReadLine();

            Console.Clear(); //очистка экрана
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Main_menu();
            a.Vie();
        }
    }
}
