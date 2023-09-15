package com.example.thefort.objects;

public class UserObject {



    private int id;
    private String user_FirstName;
    private String user_LastName;
    private String user_Contact;
    private String user_Email;
    private String user_Password;
    private String user_Type;

    private static UserObject userInstance;



    public UserObject(){};

    public UserObject(int id, String user_FirstName, String user_LastName, String user_Contact, String user_Email, String user_Password, String user_Type) {
        this.id = id;
        this.user_FirstName = user_FirstName;
        this.user_LastName = user_LastName;
        this.user_Contact = user_Contact;
        this.user_Email = user_Email;
        this.user_Password = user_Password;
        this.user_Type = user_Type;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getUser_FirstName() {
        return user_FirstName;
    }

    public void setUser_FirstName(String user_FirstName) {
        this.user_FirstName = user_FirstName;
    }

    public String getUser_LastName() {
        return user_LastName;
    }

    public void setUser_LastName(String user_LastName) {
        this.user_LastName = user_LastName;
    }

    public String getUser_Contact() {
        return user_Contact;
    }

    public void setUser_Contact(String user_Contact) {
        this.user_Contact = user_Contact;
    }

    public String getUser_Email() {
        return user_Email;
    }

    public void setUser_Email(String user_Email) {
        this.user_Email = user_Email;
    }

    public String getUser_Password() {
        return user_Password;
    }

    public void setUser_Password(String user_Password) {
        this.user_Password = user_Password;
    }

    public String getUser_Type() {
        return user_Type;
    }

    public void setUser_Type(String user_Type) {
        this.user_Type = user_Type;
    }

    public static UserObject getInstance() {
        if (userInstance == null) {
            userInstance = new UserObject();
        }
        return userInstance;
    }


}
