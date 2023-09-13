package com.example.thefort.booking.ui.home;

import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;
import androidx.recyclerview.widget.LinearLayoutManager;

import com.example.thefort.adapters.TrainerAdapter;
import com.example.thefort.databinding.FragmentHomeBinding;
import com.example.thefort.objects.TrainerObject;
import com.example.thefort.ui.IRecyclerViewClickHandler;

import java.util.ArrayList;
import java.util.List;

public class HomeFragment extends Fragment implements IRecyclerViewClickHandler{

    private FragmentHomeBinding binding;
    TrainerAdapter trainerAdapter;
    IRecyclerViewClickHandler iRecyclerViewClickHandler;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        HomeViewModel homeViewModel =
                new ViewModelProvider(this).get(HomeViewModel.class);

        binding = FragmentHomeBinding.inflate(inflater, container, false);
        View root = binding.getRoot();



        binding.browseTrainerRecycler.setLayoutManager(new LinearLayoutManager(getActivity()));

        ArrayList<TrainerObject> localDataSet = new ArrayList<>();

        for(int i = 0; i<5;i++){
            TrainerObject trainerObject = new TrainerObject(i,"hluuu"+ i,"355","This the discription","logo.jpg");

            localDataSet.add(trainerObject);

        }






        trainerAdapter  = new TrainerAdapter(localDataSet,getContext(),HomeFragment.this); // Create an instance of your adapter

        binding.browseTrainerRecycler.setAdapter(trainerAdapter);
//        recyclerView.setAdapter(adapter);
//        final TextView textView = binding.textHome;
//        homeViewModel.getText().observe(getViewLifecycleOwner(), textView::setText);



        return root;
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }


    @Override
    public void onItemClick(int position) {

        Log.d("CLICKED BUTTON", "onItemClick: ");
    }
}