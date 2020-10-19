using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
namespace PoejSeNaTo.Model
{
    public class Notes
    {
        private static SQLiteAsyncConnection conn;

        public static void Init(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Note>();
        }

        public static Task<Note> FindById(int id)
        {
            return conn.Table<Note>().Where(v => v.Id == id).FirstAsync();

        }

        public static Task<List<Note>> FindAll()
        {
            return conn.Table<Note>().ToListAsync();
        }

        public static Task<int> Store(Note note)
        {
            if (note.Id == 0)
            {               
                return conn.InsertAsync(note);
            }

            return conn.UpdateAsync(note);
        }

        public static Task<int> Delete(Note note)
        {
            return conn.DeleteAsync(note);
        }
    }
}
