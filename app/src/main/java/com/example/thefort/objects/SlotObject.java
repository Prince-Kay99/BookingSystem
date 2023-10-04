package com.example.thefort.objects;

import java.io.Serializable;

public class SlotObject implements Serializable {
    private int Id;
    private String startTime;
    private String endTime;
    private int coachId;
    private int userId;
    private String booked;

    public SlotObject() {
    }

    public SlotObject(int id, String startTime, String endTime, int coachId, int userId, String booked) {
        Id = id;
        this.startTime = startTime;
        this.endTime = endTime;
        this.coachId = coachId;
        this.userId = userId;
        this.booked = booked;
    }

    public int getId() {
        return Id;
    }

    public void setId(int id) {
        Id = id;
    }

    public String getStartTime() {
        return startTime;
    }

    public void setStartTime(String startTime) {
        this.startTime = startTime;
    }

    public String getEndTime() {
        return endTime;
    }

    public void setEndTime(String endTime) {
        this.endTime = endTime;
    }

    public int getCoachId() {
        return coachId;
    }

    public void setCoachId(int coachId) {
        this.coachId = coachId;
    }

    public int getUserId() {
        return userId;
    }

    public void setUserId(int userId) {
        this.userId = userId;
    }

    public String getBooked() {
        return booked;
    }

    public void setBooked(String booked) {
        this.booked = booked;
    }
}
