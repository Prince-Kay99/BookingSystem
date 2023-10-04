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

import com.android.volley.AuthFailureError;
import com.android.volley.DefaultRetryPolicy;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.VolleyLog;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.StringRequest;
import com.example.thefort.MainActivity;
import com.example.thefort.R;
import com.example.thefort.adapters.TrainerAdapter;
import com.example.thefort.adapters.TrainerProfileAdapter;
import com.example.thefort.booking.MainAppActivity;
import com.example.thefort.databinding.FragmentHomeBinding;
import com.example.thefort.network.URLGenerator;
import com.example.thefort.network.VolleyCallBack;
import com.example.thefort.network.VolleySingleton;
import com.example.thefort.objects.BookingObject;
import com.example.thefort.objects.TrainerObject;
import com.example.thefort.objects.UserObject;
import com.example.thefort.ui.IRecyclerViewClickHandler;
import com.google.android.material.appbar.MaterialToolbar;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.UnsupportedEncodingException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class HomeFragment extends Fragment implements IRecyclerViewClickHandler, URLGenerator {

    private FragmentHomeBinding binding;
    TrainerAdapter trainerAdapter;
    TrainerObject[] trainerObjectsList=null;

    BookingObject bookingObject;
    UserObject userObject;

    TrainerProfileAdapter trainerProfileAdapter;
    SharedPreferences sharedPreferences;
    IRecyclerViewClickHandler iRecyclerViewClickHandler;
    ArrayList<TrainerObject> localDataSet = new ArrayList<>();
    ArrayList<TrainerObject> trainerProfileSet = new ArrayList<>();
    RequestQueue requestQueue;
    String serverResponseCode;


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
        requestQueue = VolleySingleton.getVolleyInstance(getContext()).getRequestQueue();


        try {
            GETCoachRequest(new VolleyCallBack() {
                @Override
                public void OnSuccess() {



                        //    Log.e("RESPONSE CODE 200: ", serverResponseCode);
                    // Now you can access the trainerObjectsList here
                    if (trainerObjectsList != null) {
                        for (TrainerObject trainer : trainerObjectsList) {
                            Log.e("trainerObjectsList", trainer.getQualification());

                        }
                    } else {
                    }

                    // You can add the data to your localDataSet here
                    if (localDataSet != null) {
                        trainerProfileAdapter  = new TrainerProfileAdapter(trainerProfileSet,getContext(),HomeFragment.this); // Create an instance of your adapter
                        binding.allTrainersRecyclerView.setAdapter(trainerProfileAdapter);

                        trainerAdapter  = new TrainerAdapter(localDataSet,getContext(),HomeFragment.this); // Create an instance of your adapter
                        binding.browseTrainerRecycler.setAdapter(trainerAdapter);
                    }




                }
            });
        } catch (JSONException e) {
            throw new RuntimeException(e);
        }


//        TrainerObject trainerObject = new TrainerObject(1,13,"Branch 1","BSc Sport Management",
//                "Serious","5 Years","5", UserObject.getInstance(),"150","30");
//
//        for(int i = 0; i<5;i++){
//
//            localDataSet.add(trainerObject);
//            trainerProfileSet.add(trainerObject);
//        }



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

    @Override
    public String generateURL() {
        String cleanUrl = getResources().getString(R.string.WCF_URL);
        return cleanUrl + "/api/CoachProfiles";
    }

    public void GETCoachRequest(final VolleyCallBack callBack) throws JSONException {


        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(
                Request.Method.GET, generateURL(), null,
                new Response.Listener<JSONArray>() {
                    @Override
                    public void onResponse(JSONArray response) {
                        try {

                            // Process the JSON array
                            for (int i = 0; i < response.length(); i++) {
                                JSONObject jsonObject = response.getJSONObject(i);

                                Log.d("jsn obj", "onResponse: "+jsonObject);
                                int id = jsonObject.getInt("id");
                                int age = jsonObject.getInt("age");
                                String branch = jsonObject.getString("branch");
                                String qualification = jsonObject.getString("qualification");
                                String personality = jsonObject.getString("personality");
                                String experience = jsonObject.getString("experience");
                                String rating = jsonObject.getString("rating");
                                String name = jsonObject.getString("experience");
                                String surname = jsonObject.getString("rating");
                                TrainerObject trainerObject = new TrainerObject(id,age,branch,qualification,personality,experience,rating,"50",name,surname,"30");

                                localDataSet.add(trainerObject);
                            }
                            callBack.OnSuccess();
                        } catch (JSONException e) {
                            e.printStackTrace();
                            callBack.OnSuccess();
                        }
                    }
                },
                new Response.ErrorListener() {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        // Handle errors here
                    }
                });

// Add the request to the RequestQueue
        requestQueue.add(jsonArrayRequest);




        };



    }


