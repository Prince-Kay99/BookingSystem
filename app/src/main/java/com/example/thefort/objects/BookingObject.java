package com.example.thefort.objects;

public class BookingObject {

    private int ID;
    private UserObject clientObject;
    private TrainerObject trainerObject;


    public BookingObject() {
    }

    public BookingObject(int ID, UserObject clientObject, TrainerObject trainerObject) {
        this.ID = ID;
        this.clientObject = clientObject;
        this.trainerObject = trainerObject;
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

}
