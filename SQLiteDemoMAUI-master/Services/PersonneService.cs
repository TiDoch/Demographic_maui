using SQLite;
using MardocheDespagne_MAUI_demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MardocheDespagne_MAUI_demo.Services
{
    public class PersonneService : IPersonneService
    {
        private SQLiteAsyncConnection _dbConnection;

        private async Task db()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Personne.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<Personne>();
            }
        }

        public async Task<int> AddPerson(Personne personne)
        {
            await db();
            return await _dbConnection.InsertAsync(personne);
        }

        public async Task<int> DeletePerson(Personne personne)
        {
            await db();
            return await _dbConnection.DeleteAsync(personne);
        }

        public async Task<List<Personne>> GetPersonList()
        {
            await db();
            var personneList = await _dbConnection.Table<Personne>().ToListAsync();
            return personneList;
        }

        public async Task<int> UpdatePerson(Personne studentModel)
        {
            await db();
            return await _dbConnection.UpdateAsync(studentModel);
        }
    }
}
