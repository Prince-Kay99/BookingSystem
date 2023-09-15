package com.example.thefort;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;

import com.android.volley.AuthFailureError;
import com.android.volley.DefaultRetryPolicy;
import com.android.volley.NetworkResponse;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.VolleyLog;
import com.android.volley.toolbox.HttpHeaderParser;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.StringRequest;
import com.example.thefort.booking.MainAppActivity;
import com.example.thefort.databinding.FragmentLoginBinding;
import com.example.thefort.network.URLGenerator;
import com.example.thefort.network.VolleyCallBack;
import com.example.thefort.network.VolleySingleton;
import com.example.thefort.objects.UserObject;
import com.example.thefort.ui.UIComponents;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.UnsupportedEncodingException;


public class LoginFragment extends Fragment implements URLGenerator {

    RequestQueue requestQueue;
    StringRequest stringRequest;
    private FragmentLoginBinding binding;
    UIComponents uiComponents;
    String serverResponseCode;
    UserObject userObject;
    UserObject user;
    SharedPreferences userSharedPreferences;





    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        requireActivity().getWindow()
                .setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_ADJUST_NOTHING);

    }


    @Override
    public View onCreateView(
            LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState
    ) {

        binding = FragmentLoginBinding.inflate(inflater, container, false);
        return binding.getRoot();

    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        uiComponents = new UIComponents(getActivity());
        getActivity().getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_ADJUST_RESIZE);
        userSharedPreferences = requireContext().getSharedPreferences("userPref", Context.MODE_PRIVATE);

        binding.btnSignIn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {



                    requestQueue = VolleySingleton.getVolleyInstance(getContext()).getRequestQueue();
                    binding.txtEmail.setErrorEnabled(false);
                    binding.txtPassword.setErrorEnabled(false);


                try {
                    POSTLoginRequest(new VolleyCallBack() {
                        @Override
                        public void OnSuccess() {


                            if (serverResponseCode != null) {
                                if (serverResponseCode.equals("200")) {
                                    createSharedPreferences();
                                    Log.e("RESPONSE CODE 200: ", serverResponseCode);
                                    Intent intent = new Intent(getActivity(), MainAppActivity.class);
                                    intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                    startActivity(intent);
                                    requireActivity().finish();
                                } else if (serverResponseCode.equals("202")) {

                                    uiComponents.alertDialog_DefaultNoCancel("Username or password is incorrect", "Sign In Failed", "GOT IT");
                                    binding.txtPasswordEditor.setText("");
                                    binding.txtPasswordEditor.requestFocus();

                                }
                            } else {
                                uiComponents.alertDialog_DefaultNoCancel("Server is temporarily down. Please try again later", "Error", "Ok");
                            }
                            serverResponseCode = null;


                        }
                    });
                } catch (JSONException e) {
                    throw new RuntimeException(e);
                }


                //    NavHostFragment.findNavController(LoginFragment.this)
              //          .navigate(R.id.action_FirstFragment_to_SecondFragment);
            }
        });
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }



    public void createSharedPreferences(){
        SharedPreferences userSharedPreferences = requireContext().getSharedPreferences("userPref", Context.MODE_PRIVATE);
        SharedPreferences.Editor editor = userSharedPreferences.edit();
        editor.clear().apply();

        editor.putString("pref_FirstName",userObject.getUser_FirstName());
        editor.putString("pref_LastName",userObject.getUser_LastName());
        editor.putString("pref_Email",userObject.getUser_Email());
        editor.putString("pref_Phone", userObject.getUser_Contact());
        editor.putString("pref_Id",String.valueOf(userObject.getId()));
        editor.putString("pref_UserType",userObject.getUser_Type());
        editor.commit();

        UserObject user = new UserObject();
        user.setUser_Email(userObject.getUser_Email());
        user.setUser_FirstName(userObject.getUser_FirstName());
        user.setUser_LastName(userObject.getUser_LastName());
        user.setUser_Password("passw");
    }


    @Override
    public String generateURL() {
        String cleanUrl = getResources().getString(R.string.WCF_URL);
        return cleanUrl + "/api/Users/Login/login";
    }



    public void POSTLoginRequest(final VolleyCallBack callBack) throws JSONException {


        JSONObject jsonBody = new JSONObject();

        jsonBody.put("username", binding.txtEmailEditor.getText());
        jsonBody.put("password", binding.txtPasswordEditor.getText());

        final String mRequestBody = jsonBody.toString();

        StringRequest stringRequest = new StringRequest(Request.Method.POST, generateURL(), new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                String jsonObj = response.toString();

                Log.e("VOLLEYRESPONSE", "onResponse: "+response);

                if (jsonObj.contains("id") && jsonObj.contains("user_FirstName") ) {
                    GsonBuilder builder = new GsonBuilder();
                    builder.serializeNulls();
                    Gson gson = builder.setPrettyPrinting().create();
                    userObject = gson.fromJson(jsonObj, UserObject.class);
                    Log.e("VOLLEYLOGGED", "logged user "+userObject.getUser_Email());

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
                Log.e("Succes response",error.toString());
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



