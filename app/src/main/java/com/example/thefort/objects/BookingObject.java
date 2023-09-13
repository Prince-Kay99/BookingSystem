package com.example.thefort.objects;

public class BookingObject {

    private int ID;
    private UserObject clientObject;
    private TrainerObject trainerObject;
    private String date;
    private String sessionMinutes;

    public BookingObject() {
    }

    public BookingObject(int ID, UserObject clientObject, TrainerObject trainerObject, String date, String sessionMinutes) {
        this.ID = ID;
        this.clientObject = clientObject;
        this.trainerObject = trainerObject;
        this.date = date;
        this.sessionMinutes = sessionMinutes;
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
        return date;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public String getSessionMinutes() {
        return sessionMinutes;
    }

    public void setSessionMinutes(String sessionMinutes) {
        this.sessionMinutes = sessionMinutes;
    }
}
