package com.example.thefort.objects;

import java.io.Serializable;

public class TrainerObject implements Serializable {
    private int ID;
    private int trainer_id;
    private String Name;
    private String Price;
    private String Duration;
    private String Date;
    private String Time;
    private String image;


    public TrainerObject() {
    }

    public TrainerObject(int ID, int trainer_id, String name, String price, String duration, String date, String time, String image) {
        this.ID = ID;
        this.trainer_id = trainer_id;
        Name = name;
        Price = price;
        Duration = duration;
        Date = date;
        Time = time;
        this.image = image;
    }

    public int getID() {
        return ID;
    }

    public void setID(int ID) {
        this.ID = ID;
    }

    public int getTrainer_id() {
        return trainer_id;
    }

    public void setTrainer_id(int trainer_id) {
        this.trainer_id = trainer_id;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
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

    public String getDate() {
        return Date;
    }

    public void setDate(String date) {
        Date = date;
    }

    public String getTime() {
        return Time;
    }

    public void setTime(String time) {
        Time = time;
    }

    public String getImage() {
        return image;
    }

    public void setImage(String image) {
        this.image = image;
    }
}
