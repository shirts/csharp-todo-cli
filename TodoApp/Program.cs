using System;
using System.IO;

public class Program {
    public static void Main(string[] args)
    {
        string action = (args.Length == 0) ? "" : args[0];

        var todoList = new TodoList();

        switch(action)
        {
            case "add":
                string text = String.Join(" ", args[1..]);
                todoList.Add(text);
                break;
            case "complete":
                int index = int.Parse(args[1]);
                todoList.Complete(index);
                break;
            case "reset":
                todoList.Reset();
                break;
        }
        todoList.Show();
    }
}

public interface ITodoItem
{
    string Text { get; set; }
}

public class TodoItem : ITodoItem
{
    public string Text { get; set; } = "";
    public TodoItem(string text)
    {
        Text = text;
    }
}

public class TodoList
{
    public List<TodoItem> Items = new List<TodoItem>();

    public void Show()
    {
        if (!Items.Any())
        {
            Console.WriteLine("Hooray! No Items");
            return;
        }
        for (int i = 0; i < Items.Count; i++)
        {
            Console.WriteLine($"{i}: {Items[i].Text}");
        }
    }
    public void Add(string text)
    {
        Items.Add(new TodoItem(text));
    }
    public void Complete(int index)
    {
        Items.RemoveAt(index);
    }
    public void Reset()
    {
        Items.Clear();
    }
}
