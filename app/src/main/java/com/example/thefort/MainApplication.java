package com.example.thefort;

import android.app.Application;

import com.google.android.material.color.DynamicColors;

public class MainApplication extends Application {
    @Override
    public void onCreate() {
        super.onCreate();

        // Apply dynamic colors to activities
        DynamicColors.applyToActivitiesIfAvailable(this);

        // Other initialization code for your application
    }
}
