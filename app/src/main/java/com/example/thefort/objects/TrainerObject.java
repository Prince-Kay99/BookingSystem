package com.example.thefort.objects;

import java.io.Serializable;

public class TrainerObject implements Serializable {
    private int ID;
    private String Name;
    private String Price;
    private String Description;
    private String image;


    public TrainerObject() {
    }

    public TrainerObject(int ID, String name, String price, String description, String image) {
        this.ID = ID;
        Name = name;
        Price = price;
        Description = description;
        this.image = image;
    }


    public int getID() {
        return ID;
    }

    public void setID(int ID) {
        this.ID = ID;
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

    public String getDescription() {
        return Description;
    }

    public void setDescription(String description) {
        Description = description;
    }

    public String getImage() {
        return image;
    }

    public void setImage(String image) {
        this.image = image;
    }
}
