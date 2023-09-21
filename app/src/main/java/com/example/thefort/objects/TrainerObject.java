package com.example.thefort.objects;

import java.io.Serializable;

public class TrainerObject implements Serializable {
    private int Id;
    private int Age;
    private String Branch;
    private String Qualification;
    private String Personality;
    private String Experience;
    private String Rating;
    private UserObject userObject;
    private String Price;
    private String Duration;


    public TrainerObject() {
    }

    public TrainerObject(int id, int age, String branch, String qualification, String personality, String experience, String rating, UserObject userObject, String price, String duration) {
        Id = id;
        Age = age;
        Branch = branch;
        Qualification = qualification;
        Personality = personality;
        Experience = experience;
        Rating = rating;
        this.userObject = userObject;
        Price = price;
        Duration = duration;
    }

    public int getId() {
        return Id;
    }

    public void setId(int id) {
        Id = id;
    }

    public int getAge() {
        return Age;
    }

    public void setAge(int age) {
        Age = age;
    }

    public String getBranch() {
        return Branch;
    }

    public void setBranch(String branch) {
        Branch = branch;
    }

    public String getQualification() {
        return Qualification;
    }

    public void setQualification(String qualification) {
        Qualification = qualification;
    }

    public String getPersonality() {
        return Personality;
    }

    public void setPersonality(String personality) {
        Personality = personality;
    }

    public String getExperience() {
        return Experience;
    }

    public void setExperience(String experience) {
        Experience = experience;
    }

    public String getRating() {
        return Rating;
    }

    public void setRating(String rating) {
        Rating = rating;
    }

    public UserObject getUserObject() {
        return userObject;
    }

    public void setUserObject(UserObject userObject) {
        this.userObject = userObject;
    }

    public String getPrice() {
        return Price;
    }

    public void setPrice(String price) {
        Price = price;
    }

    public String getDuration() {
        return Duration;
    }

    public void setDuration(String duration) {
        Duration = duration;
    }
}
