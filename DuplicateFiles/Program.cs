using DuplicateFiles;

var path = $"{AppDomain.CurrentDomain.BaseDirectory}\\Files\\";
foreach(var dupl in SearchFiles.GetDuplicates(path))
{
    Console.WriteLine(String.Join('\n',dupl.Paths));
    Console.WriteLine();
}