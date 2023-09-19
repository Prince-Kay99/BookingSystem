package com.example.thefort.booking.ui.dashboard;

import android.content.Intent;
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

import com.android.volley.AuthFailureError;
import com.android.volley.DefaultRetryPolicy;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.VolleyLog;
import com.android.volley.toolbox.StringRequest;
import com.example.thefort.R;
import com.example.thefort.booking.MainAppActivity;
import com.example.thefort.databinding.FragmentDashboardBinding;
import com.example.thefort.network.URLGenerator;
import com.example.thefort.network.VolleyCallBack;
import com.example.thefort.network.VolleySingleton;
import com.example.thefort.objects.BookingObject;
import com.example.thefort.objects.TrainerObject;
import com.example.thefort.objects.UserObject;
import com.google.android.material.appbar.MaterialToolbar;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.UnsupportedEncodingException;

public class DashboardFragment extends Fragment implements URLGenerator {

    private FragmentDashboardBinding binding;
    private TrainerObject trainerObject;
    private BookingObject bookingObject;
    RequestQueue requestQueue;
    String serverResponseCode;


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
             bookingObject.setClientObject(user);
             binding.txtBookName2.setText(trainerObject.getName());
            binding.txtBookPrice.setText("R "+trainerObject.getPrice());
            binding.txtBookDate.setText(trainerObject.getDate());
            binding.txtBookTime.setText(trainerObject.getTime());
            binding.txtBookDuration.setText(trainerObject.getDuration()+" mins");


        }


        binding.btnBookReserve.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {


                requestQueue = VolleySingleton.getVolleyInstance(getContext()).getRequestQueue();



                try {
                    POSTMakeBookingRequest(new VolleyCallBack() {
                        @Override
                        public void OnSuccess() {


                            if (serverResponseCode != null) {
                                if (serverResponseCode.equals("200")) {
                                    Log.e("RESPONSE CODE 200: ", serverResponseCode);
                                    Intent intent = new Intent(getActivity(), MainAppActivity.class);
                                    intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                    startActivity(intent);
                                    requireActivity().finish();
                                } else if (serverResponseCode.equals("202")) {



                                }
                            } else {
                            }
                            serverResponseCode = null;


                        }
                    });
                } catch (JSONException e) {
                    throw new RuntimeException(e);
                }







            }
        });

        return root;
    }


    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }


    @Override
    public String generateURL() {
        String cleanUrl = getResources().getString(R.string.WCF_URL);
        return cleanUrl + "/api/Users/Login/login";
    }




    public void POSTMakeBookingRequest(final VolleyCallBack callBack) throws JSONException {


        JSONObject jsonBody = new JSONObject();

        jsonBody.put("bookingObject",bookingObject);

        final String mRequestBody = jsonBody.toString();

        StringRequest stringRequest = new StringRequest(Request.Method.POST, generateURL(), new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                String jsonObj = response.toString();

                Log.e("VOLLEYRESPONSE", "onResponse: "+response);

                if (jsonObj.contains("Id")  ) {
                    GsonBuilder builder = new GsonBuilder();
                    builder.serializeNulls();
                    Gson gson = builder.setPrettyPrinting().create();
//                    userObject = gson.fromJson(jsonObj, UserObject.class);
//                    Log.e("VOLLEYLOGGED", "logged user "+userObject.getUser_Email());

                    serverResponseCode = getResources().getString(R.string.response_success);
                }else if(jsonObj.contains("0")){
                    serverResponseCode="201";
                }else if(jsonObj.contains("-1")){
                    serverResponseCode="202";
                }else {
                    serverResponseCode = getResources().getString(R.string.response_login_error);
                    Log.e("Inside response", "returned null object from server login");
                }

                callBack.OnSuccess();

            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                VolleyLog.e("Error: ", error.getMessage());
                Log.e("Success response",error.toString());
                serverResponseCode = null;
                callBack.OnSuccess();
            }
        }){
            @Override
            public String getBodyContentType() {
                return "application/json; charset=utf-8";
            }


            @Override
            public byte[] getBody() throws AuthFailureError {
                try {
                    return mRequestBody == null ? null : mRequestBody.getBytes("utf-8");
                } catch (UnsupportedEncodingException uee) {
                    VolleyLog.wtf("Unsupported Encoding while trying to get the bytes of %s using %s", mRequestBody, "utf-8");
                    return null;
                }
            }


        };


        stringRequest.setRetryPolicy(new DefaultRetryPolicy(3000, 3, DefaultRetryPolicy.DEFAULT_BACKOFF_MULT));

        requestQueue.add(stringRequest);
    }


}