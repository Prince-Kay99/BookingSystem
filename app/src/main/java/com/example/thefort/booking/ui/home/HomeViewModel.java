package com.example.thefort.booking.ui.home;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;
import androidx.recyclerview.widget.RecyclerView;

public class HomeViewModel extends ViewModel {

    private final MutableLiveData<String> mText;
    private final MutableLiveData<RecyclerView> recyclerTrainer;

    public HomeViewModel() {
        mText = new MutableLiveData<>();
        mText.setValue("This is home fragment");


        recyclerTrainer = new MutableLiveData<>();

    }


    public LiveData<String> getText() {
        return mText;
    }
}