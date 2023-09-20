package com.example.thefort.objects;

public class BookingObject {

    private int ID;
    private UserObject clientObject;
    private TrainerObject trainerObject;
    private String Date;
    private String Time;


    public BookingObject() {
    }

    public BookingObject(int ID, UserObject clientObject, TrainerObject trainerObject, String date, String time) {
        this.ID = ID;
        this.clientObject = clientObject;
        this.trainerObject = trainerObject;
        Date = date;
        Time = time;
    }

    public int getID() {
        return ID;
    }

    public void setID(int ID) {
        this.ID = ID;
    }

    public UserObject getClientObject() {
        return clientObject;
    }

    public void setClientObject(UserObject clientObject) {
        this.clientObject = clientObject;
    }

    public TrainerObject getTrainerObject() {
        return trainerObject;
    }

    public void setTrainerObject(TrainerObject trainerObject) {
        this.trainerObject = trainerObject;
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
}
