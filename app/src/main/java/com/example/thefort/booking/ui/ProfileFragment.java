package com.example.thefort.booking.ui;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.thefort.R;
import com.example.thefort.adapters.SlotsAdapter;
import com.example.thefort.booking.ui.notifications.NotificationsFragment;
import com.example.thefort.databinding.FragmentNotificationsBinding;
import com.example.thefort.databinding.FragmentProfileBinding;
import com.example.thefort.objects.SlotObject;
import com.example.thefort.objects.TrainerObject;
import com.example.thefort.ui.IRecyclerViewClickHandler;

import java.util.ArrayList;

public class ProfileFragment extends Fragment implements IRecyclerViewClickHandler {

    private FragmentProfileBinding binding;
    ArrayList<SlotObject> localDataSet = new ArrayList<>();


    public ProfileFragment() { }

//    public static ProfileFragment newInstance(String param1, String param2) {
//        ProfileFragment fragment = new ProfileFragment();
//        Bundle args = new Bundle();
//
//        fragment.setArguments(args);
//        return fragment;
//    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {


        binding = FragmentProfileBinding.inflate(inflater, container, false);
        View root = binding.getRoot();




        return root;
//        return inflater.inflate(R.layout.fragment_profile, container, false);
    }

    @Override
    public void onItemClick(int position) {

    }

    @Override
    public void onProfileClick(int position) {

    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
}