﻿using System.Net;
using System.Net.Mail;
using System.Reflection;

var notifierBuilder = new NotifierBuilder();

Notifier decorator = notifierBuilder
    .Add<ConsoleNotifier>()
    .Add<FileNotifier>()
    .Add<MailNotifier>()
    .Build();

decorator.Notify(new Message()
{
    From = "skiba_al@itstep.edu.az",
    To = "faar.haag@gmail.com",
    Text = @"Farhad joke count: 1"
});

public class Message
{
    public string From { get; set; } = null!;
    public string To { get; set; } = null!;
    public string Text { get; set; } = null!;
}


public abstract class Notifier
{
    public abstract void Notify(Message message);
}

public abstract class NotifierDecorator : Notifier
{
    protected Notifier? BaseNotifier;

    public NotifierDecorator(Notifier? notifier)
    {
        BaseNotifier = notifier;
    }
}

public class FileNotifier : NotifierDecorator
{
    public FileNotifier(Notifier? notifier = null) : base(notifier)
    {
    }

    public override void Notify(Message message)
    {
        BaseNotifier?.Notify(message);

        File.WriteAllText("log.txt", $"From: {message.From}\nTo:{message.To}\nText:{message.Text}");
    }
}

public class ConsoleNotifier : NotifierDecorator
{
    public ConsoleNotifier(Notifier? notifier = null) : base(notifier)
    {
    }

    public override void Notify(Message message)
    {
        BaseNotifier?.Notify(message);

        Console.WriteLine($"From: {message.From}\nTo:{message.To}\nText:{message.Text}");
    }
}

public class MailNotifier : NotifierDecorator
{
    public MailNotifier(Notifier? notifier = null) : base(notifier)
    {
        Console.WriteLine("Created!");
    }

    public override void Notify(Message message)
    {
        BaseNotifier?.Notify(message);

        var myLogin = message.From;
        var myPassword = File.ReadAllText("password");
        var smtpClient = new SmtpClient("smtp-mail.outlook.com", 587)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential()
            {
                UserName = myLogin,
                Password = myPassword
            }
        };
        var from = new MailAddress(message.From);
        var to = new MailAddress(message.To);
        var mailMessage = new MailMessage(from, to)
        {
            Subject = "Test message",
            Body = message.Text
        };

        smtpClient.SendCompleted += (sender, args) => { Console.WriteLine("Message sent"); };

        smtpClient.Send(mailMessage);
    }
}


public class GmailNotifier : NotifierDecorator
{
    public GmailNotifier(Notifier? notifier) : base(notifier)
    {
    }

    public override void Notify(Message message)
    {
        throw new NotImplementedException();
    }
}
// Builder for Decorator pattern

public class NotifierBuilder
{
    private Stack<Type> _types;

    public NotifierBuilder()
    {
        _types = new();
    }

    public NotifierBuilder Add<T>()
        where T : Notifier
    {
        _types.Push(typeof(T));

        return this;
    }

    public Notifier Build()
    {
        if (_types.Count == 0)
        {
            throw new InvalidOperationException("Notifier list is empty!");
        }


        object? instance = null;

        while (_types.Count != 0)
        {
            Type currentType = _types.Pop();
            ConstructorInfo constructor = currentType.GetConstructors().First(c => c.GetParameters().Count() == 1);
            object?[] args = new object?[] { instance };

            instance = constructor.Invoke(args);
        }

        return (instance as Notifier)!;
    }
}