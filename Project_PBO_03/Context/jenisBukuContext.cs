﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using Project_PBO_03.Core;
using Project_PBO_03.Model;

namespace Project_PBO_03.Context
{
    internal class JenisBukuContext : DBconnection
    {
        public static string table = "jenisbuku";

        public static DataTable all()
        {
            string query = $"SELECT * FROM {table}";
            DataTable dataJenis = queryExecutor(query);
            return dataJenis;
        }

        public static DataTable comboBox()
        {
            string query = $"SELECT namajenis FROM {table}";
            DataTable dataJenis = queryExecutor(query);
            return dataJenis;
        }

        public static void create(m_JenisBuku jenisBaru)
        {
            string query = $"INSERT INTO {table} (namajenis) VALUES (@namajenis)";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@namajenis", NpgsqlDbType.Varchar) {Value = jenisBaru.nama_jenis}
            };
            commandExecutor(query, parameters);
        }

        public static void delete(int id)
        {
            string query = $"DELETE FROM {table} WHERE idpenerbit = @idjenis";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@idjenis", NpgsqlDbType.Integer) {Value = id},
            };
            commandExecutor(query, parameters);
        }

    }
     
}