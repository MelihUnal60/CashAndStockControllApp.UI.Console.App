using System.Text;

namespace CashAndStockControlApp.Data.txt
{
    public class FileOperations
    {
        public static void Save(string fileRoad, string content)
        {
            File.WriteAllText(fileRoad, content);
        }
        public static string Read(string fileRoad)
        {
            try
            {
                return File.ReadAllText(fileRoad);
            }
            catch (Exception ex)
            {

                StringBuilder sb= new StringBuilder();
                sb.Append("*********************************\r\n");
                sb.Append($"Log zamanı : {DateTime.Now}\r\n");
                sb.Append($"Hata mesajı : {ex.Message}\r\n");
                sb.Append($"Dosya yolu : {fileRoad}\r\n");
                sb.Append($"********************************\r\n");

                File.AppendAllText("log.txt",sb.ToString());
                
                throw new FileNotFoundException(fileRoad);
                
            }
        }
    }
}