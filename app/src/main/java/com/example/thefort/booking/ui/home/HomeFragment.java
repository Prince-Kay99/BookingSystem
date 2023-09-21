package com.example.thefort.booking.ui.home;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;
import androidx.navigation.Navigation;
import androidx.navigation.fragment.NavHostFragment;
import androidx.recyclerview.widget.LinearLayoutManager;

import com.example.thefort.MainActivity;
import com.example.thefort.R;
import com.example.thefort.adapters.TrainerAdapter;
import com.example.thefort.adapters.TrainerProfileAdapter;
import com.example.thefort.booking.MainAppActivity;
import com.example.thefort.databinding.FragmentHomeBinding;
import com.example.thefort.objects.BookingObject;
import com.example.thefort.objects.TrainerObject;
import com.example.thefort.objects.UserObject;
import com.example.thefort.ui.IRecyclerViewClickHandler;
import com.google.android.material.appbar.MaterialToolbar;

import java.util.ArrayList;
import java.util.List;

public class HomeFragment extends Fragment implements IRecyclerViewClickHandler{

    private FragmentHomeBinding binding;
    TrainerAdapter trainerAdapter;
    BookingObject bookingObject;
    TrainerProfileAdapter trainerProfileAdapter;
    SharedPreferences sharedPreferences;
    IRecyclerViewClickHandler iRecyclerViewClickHandler;
    ArrayList<TrainerObject> localDataSet = new ArrayList<>();
    ArrayList<TrainerObject> trainerProfileSet = new ArrayList<>();

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        HomeViewModel homeViewModel =
                new ViewModelProvider(this).get(HomeViewModel.class);

        binding = FragmentHomeBinding.inflate(inflater, container, false);
        View root = binding.getRoot();

//        if (getActivity() instanceof MainAppActivity) {
//            Toolbar toolbar = ((MainAppActivity) getActivity()).getToolbar();
//
//            // Now you can work with the Toolbar
//            if (toolbar != null) {
//                toolbar.setVisibility(View.GONE);
//            }
//        }

//        toolbar.setVisibility(View.GONE);

        SharedPreferences sharedPreferences = getContext().getSharedPreferences("userPref", Context.MODE_PRIVATE);
        String name = sharedPreferences.getString("pref_FirstName", "")+ " " +sharedPreferences.getString("pref_LastName", "");
        binding.txtHomeName.setText(name);
        binding.txtHomeEmail.setText(sharedPreferences.getString("pref_Email", ""));

        binding.browseTrainerRecycler.setLayoutManager(new LinearLayoutManager(getActivity()));
        LinearLayoutManager layoutManager = new LinearLayoutManager(getContext(), LinearLayoutManager.HORIZONTAL, false);
        binding.allTrainersRecyclerView.setLayoutManager(layoutManager);

        TrainerObject trainerObject = new TrainerObject(1,13,"Branch 1","BSc Sport Management",
                "Serious","5 Years","5", UserObject.getInstance(),"150","30");

        for(int i = 0; i<5;i++){

            localDataSet.add(trainerObject);
            trainerProfileSet.add(trainerObject);
        }

        trainerProfileAdapter  = new TrainerProfileAdapter(trainerProfileSet,getContext(),HomeFragment.this); // Create an instance of your adapter
        binding.allTrainersRecyclerView.setAdapter(trainerProfileAdapter);

        trainerAdapter  = new TrainerAdapter(localDataSet,getContext(),HomeFragment.this); // Create an instance of your adapter
        binding.browseTrainerRecycler.setAdapter(trainerAdapter);

        return root;

    }


    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        // Access the Toolbar from MainActivity

    }



    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }




    @Override
    public void onItemClick(int position) {
        Log.d("CLICKED BUTTON", "btn clicked");

        Bundle bundle = new Bundle();
     bookingObject = new BookingObject();
       bookingObject.setTrainerObject(localDataSet.get(position));
       bookingObject.setClientObject(UserObject.getInstance());
        bookingObject.setDate("13 November 2023");
        bookingObject.setTime("03:00 - 04:00");
       bundle.putSerializable("clickedBookingSlot",bookingObject);
        NavHostFragment.findNavController(HomeFragment.this)
                .navigate(R.id.action_navigation_home_to_navigation_dashboard,bundle);
    }

    @Override
    public void onProfileClick(int position) {

        Log.d("CLICKED profile", "onItemClick: ");



        Bundle bundle = new Bundle();
        TrainerObject trainer = new TrainerObject();
        trainer= localDataSet.get(position);
        bundle.putSerializable("clickedTrainSlot",trainer);
        NavHostFragment.findNavController(HomeFragment.this)
                .navigate(R.id.action_navigation_home_to_navigation_notifications,bundle);

    }

}