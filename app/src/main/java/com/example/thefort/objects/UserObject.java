package com.example.thefort.objects;

public class UserObject {

    private int Id;
    private String Name;
    private String Surname;
    private String Email;
    private int PhoneNo;
    private String Gender;
    private String UserType;

    public UserObject(){};

    public UserObject(int Id, String Name, String Surname, String Email, int PhoneNo, String Gender, String UserType) {
        this.Id = Id;
        this.Name = Name;
        this.Surname = Surname;
        this.Email = Email;
        this.PhoneNo = PhoneNo;
        this.Gender = Gender;
        this.UserType = UserType;
    }

    public int getId() {
        return Id;
    }

    public void setId(int id) {
        Id = id;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }

    public String getSurname() {
        return Surname;
    }

    public void setSurname(String surname) {
        Surname = surname;
    }

    public String getEmail() {
        return Email;
    }

    public void setEmail(String email) {
        Email = email;
    }

    public int getPhoneNo() {
        return PhoneNo;
    }

    public void setPhoneNo(int phoneNo) {
        PhoneNo = phoneNo;
    }

    public String getGender() {
        return Gender;
    }

    public void setGender(String gender) {
        Gender = gender;
    }

    public String getUserType() {
        return UserType;
    }

    public void setUserType(String userType) {
        UserType = userType;
    }



}
