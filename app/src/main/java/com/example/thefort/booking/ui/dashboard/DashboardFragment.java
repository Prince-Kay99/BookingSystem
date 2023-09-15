package com.example.thefort.booking.ui.dashboard;

import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.ui.AppBarConfiguration;
import androidx.navigation.ui.NavigationUI;

import com.example.thefort.R;
import com.example.thefort.databinding.FragmentDashboardBinding;
import com.example.thefort.objects.BookingObject;
import com.example.thefort.objects.TrainerObject;
import com.example.thefort.objects.UserObject;
import com.google.android.material.appbar.MaterialToolbar;

public class DashboardFragment extends Fragment {

    private FragmentDashboardBinding binding;
    private TrainerObject trainerObject;
    private BookingObject bookingObject;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        DashboardViewModel dashboardViewModel =
                new ViewModelProvider(this).get(DashboardViewModel.class);

        binding = FragmentDashboardBinding.inflate(inflater, container, false);
        View root = binding.getRoot();
        bookingObject = new BookingObject();


        Bundle args = getArguments();
        if (args != null) {
             trainerObject = (TrainerObject) args.getSerializable("clickedTrainSlot");
             bookingObject.setTrainerObject(trainerObject);
             UserObject user = UserObject.getInstance();
            Log.d("mnmn", "onCreateView: "+ user.getUser_Email());
             bookingObject.setClientObject(user);

             binding.txtBookName2.setText(trainerObject.getName());
            binding.txtBookPrice.setText("R "+trainerObject.getPrice());
        }


//        final TextView textView = binding.textDashboard;
//        dashboardViewModel.getText().observe(getViewLifecycleOwner(), textView::setText);
        return root;
    }


    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
}