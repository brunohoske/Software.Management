﻿using MySql.Data.MySqlClient;
using Restaurante.DAL;
using Restaurante.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.BLL
{
    internal class DAOCheck
    {
        MySqlConnection conexao = null;
        FabricaConexao f = new FabricaConexao();

        
        public void Cadastrar(Check c)
        {
            try
            {
                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                comando.CommandText = "INSERT INTO CHECKS (check_number, CNPJ)" +
                $"values({c.Check_number},'42591651000143')";
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Mesas não podem se repetir");
            }
            finally
            {
                f.Conectar().Close();
            }
        }

        public void Update(Check c, double newNumber)
        {
            try
            {
                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                string tabela = "CHECKS";
                comando.CommandText = $@"UPDATE {tabela}
                SET CHECK_NUMBER = '{newNumber}' 
                WHERE CHECK_NUMBER = {c.Check_number}";
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception("Problemas ao alterar mesa" + ex.Message);
            }
            finally
            {
                f.Conectar().Close();
            }
        }

        public void Delete(Check c)
        {
            try
            {
                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                string tabela = "CHECKS";
                comando.CommandText = String.Format($@"DELETE from {tabela} 
                WHERE check_number = '{c.Check_number}';");
                comando.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                throw new Exception("problemas ao apagar mesa" + ex.Message);
            }
            finally
            {
                f.Conectar().Close();
            }
        }


    }
}
