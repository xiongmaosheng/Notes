using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Models
{
    public class AllNotes
    {
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

        public AllNotes() => LoadNotes();

        public void LoadNotes()
        {
            Notes.Clear();
            //获取存储笔记的文件夹。
            string appDataPath = FileSystem.AppDataDirectory;
            //使用Linq扩展来加载*.notes.txt文件。
            IEnumerable<Note> notes = Directory
                //从目录中选择文件名
                .EnumerateFiles(appDataPath, "*.notes.txt")
                //每个文件名用于创建一个新的Note
                .Select(filename => new Note()
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                })
                //对于最后收集的笔记，按日期排序
                .OrderBy(note => note.Date);
            //将每个笔记添加到ObservableCollection中
            foreach (Note note in notes)
            {
                Notes.Add(note);
            }
        }
    }
}
