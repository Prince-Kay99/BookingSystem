package com.example.thefort.booking.ui.notifications;

import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;
import androidx.navigation.fragment.NavHostFragment;
import androidx.recyclerview.widget.LinearLayoutManager;

import com.example.thefort.R;
import com.example.thefort.adapters.SlotsAdapter;
import com.example.thefort.adapters.TrainerAdapter;
import com.example.thefort.adapters.TrainerProfileAdapter;
import com.example.thefort.booking.ui.home.HomeFragment;
import com.example.thefort.databinding.FragmentNotificationsBinding;
import com.example.thefort.objects.BookingObject;
import com.example.thefort.objects.SlotObject;
import com.example.thefort.objects.TrainerObject;
import com.example.thefort.objects.UserObject;
import com.example.thefort.ui.IRecyclerViewClickHandler;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Locale;

public class NotificationsFragment extends Fragment implements IRecyclerViewClickHandler{

    private FragmentNotificationsBinding binding;
    SlotsAdapter slotsAdapter;
    TrainerObject trainerObject;
    BookingObject bookingObject;
    IRecyclerViewClickHandler iRecyclerViewClickHandler;
    ArrayList<SlotObject> localDataSet = new ArrayList<>();



    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        NotificationsViewModel notificationsViewModel =
                new ViewModelProvider(this).get(NotificationsViewModel.class);

        binding = FragmentNotificationsBinding.inflate(inflater, container, false);
        View root = binding.getRoot();


        binding.recyclerViewSlots.setLayoutManager(new LinearLayoutManager(getActivity(), LinearLayoutManager.VERTICAL, false));


        for(int i = 0; i<5;i++){
            SlotObject slotObject = new SlotObject(i,"8:01 AM "+ i,"9:00 AM",i+2,1,"Pending "+i);

            localDataSet.add(slotObject);
          //  Log.d("Email in trainer", "onCreateView: "+localDataSet.get(i).getUserObject().getUser_Email());

        }


        slotsAdapter  = new SlotsAdapter(localDataSet,getContext(),NotificationsFragment.this); // Create an instance of your adapter
        binding.recyclerViewSlots.setAdapter(slotsAdapter);


        Bundle args = getArguments();
        if (args != null) {
            trainerObject = (TrainerObject) args.getSerializable("clickedTrainSlot");
            binding.txtSlotName.setText(trainerObject.getUserObject().getUser_FirstName() + " "+ trainerObject.getUserObject().getUser_LastName());
            binding.txtTrainerType.setText("Fitness");
            binding.txtSlotExp.setText(trainerObject.getExperience());
            binding.txtSlotClients.setText("100+");
            binding.txtSlotRatings.setText(trainerObject.getRating()+".0");
            binding.txtSlotDate.setText("3 November 2023");
        }


        return root;
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }

    @Override
    public void onItemClick(int position) {
        Date currentDate = new Date();
        SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd", Locale.getDefault());
        String formattedDate = dateFormat.format(currentDate);

        Bundle bundle = new Bundle();
        bookingObject = new BookingObject();
        bookingObject.setClientObject(UserObject.getInstance());
        bookingObject.setTrainerObject(trainerObject);
        bookingObject.setTime(localDataSet.get(position).getStartTime()+" - "+localDataSet.get(position).getEndTime());
        bookingObject.setDate(formattedDate);
        bundle.putSerializable("clickedBookingSlot",bookingObject);
        NavHostFragment.findNavController(NotificationsFragment.this)
                .navigate(R.id.action_navigation_notifications_to_navigation_dashboard,bundle);

    }

    @Override
    public void onProfileClick(int position) {

    }
}