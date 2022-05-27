//create a ClientFactory class. Its sole method, createClient, accepts string clientType and string userName.
//创建一个 ClientFactory 类。 它的唯一方法 createClient 接受字符串 clientType 和字符串 userName。
public abstract class ClientHandler
{
    public ClientFactory ClientFactory { get; set; }

    public abstract Client CreateClient(string type, string name);
}

public class RetailClientHandler : ClientHandler
{
    public RetailClientHandler()
    {
        ClientFactory = new ClientFactory();
    }

    public override Client CreateClient(string type, string name)
    {
        return ClientFactory.CreateClient(type, name);
    }

}

public class EnterpriseClientHandler : ClientHandler
{
    AccessBehaviour AccessBehaviour { get; set; }
    public EnterpriseClientHandler()
    {
        ClientFactory = new ClientFactory();
        AccessBehaviour = new CheckStiring();
    }

    public override Client CreateClient(string type, string name)
    {
        return ClientFactory.CreateClient(type, name);
    }
}

public class ClientFactory
{
    public Client CreateClient(string type, string name)
    {
        Client newClient = new User(name);
        if (type == "Manager")
        {
            newClient = new Manager(name);
        }
        else if (type == "Admin")
        {
            newClient = new Admin(name);
        }

        newClient.BuilAuthString(name);
        return newClient;
    }
}

/*
 Create a Client interface with the properties string UserName, string UserAuthString, and bool HasAccess. It also has a BuildAuthString method.
使用属性字符串 UserName、字符串 UserAuthString 和 bool HasAccess 创建一个客户端接口。它还有一个 BuildAuthString 方法。*/
public interface Client
{
    public string UserName { get; set; }
    public string UserAuthString { get; set; }
    public bool HasAccess { get; set; }
    public void BuilAuthString(string UserName);

}

//The User subclass has the UserAuthString remain the same as UserName and its HasAccess defaults to False.
// User 子类的 UserAuthString 与 UserName 保持相同，其 HasAccess 默认为 False。
public class User : Client
{
    public string UserName { get; set; }
    public string UserAuthString { get; set; }

    public bool HasAccess { set; get; } = false;

    public User(string name)
    {
        UserName = name;
    }
    public void BuilAuthString(string UserName)
    {
        UserAuthString = UserName;
    }
}

//The Manager and Admin subclasses append MAN and ADMIN to their UserAuthString properties on construction, and they default to true. 
//Manager 和 Admin 子类在构造时将 MAN 和 ADMIN 附加到它们的 UserAuthString 属性中，并且它们默认为 true。
public class Manager : Client
{
    public string UserName { get; set; }
    public string UserAuthString { get; set; }

    public bool HasAccess { set; get; } = true;

    public Manager(string name)
    {
        UserName = name;
    }
    public void BuilAuthString(string UserName)
    {
        UserAuthString = UserName + "ADMIN";
    }
}

public class Admin : Client
{
    public string UserName { get; set; }
    public string UserAuthString { get; set; }

    public bool HasAccess { set; get; } = true;

    public Admin(string name)
    {
        UserName = name;
    }
    public void BuilAuthString(string UserName)
    {
        UserAuthString = UserName + "ADMIN";
    }
}

//Also create an AccessBehaviour interface, which has the property Client Client and the method HandleAccess. 
//还要创建一个 AccessBehaviour 接口，该接口具有属性 Client Client 和方法 HandleAccess。
public interface AccessBehaviour
{
    public Client Client { get; set; }

    public bool HandleAccess(Client User);
}

//The interface should be implemented in two subclasses, CheckString (which checks if the Client’s UserAuthString ends with “ADMIN” and returns the result as a boolean) and SwitchAuth (which returns the Client’s HasAccess property, and then switches that property’s value).
//该接口应在两个子类中实现，CheckString（检查客户端的 UserAuthString 是否以“ADMIN”结尾并将结果作为布尔值返回）和 SwitchAuth（返回客户端的 HasAccess 属性，然后切换该属性的值）。
public class CheckStiring : AccessBehaviour
{
    public Client Client { set; get; }

    public CheckStiring()
    {

    }
    public bool HandleAccess(Client user)
    {
        var initialValue = user.UserAuthString;
        bool result = false;
        if (initialValue.Substring(initialValue.Length - 5) == "ADMIN")
            result = true;

        return result;
    }
}

public class SwichAuth : AccessBehaviour
{
    public Client Client { set; get; }

    public bool HandleAccess(Client user)
    {
        if (user.HasAccess)
        {
            user.HasAccess = false;
        }
        else if (!user.HasAccess)
        {
            user.HasAccess = true;
        }

        return user.HasAccess;
    }
}