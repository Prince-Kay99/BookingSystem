package com.example.thefort;

import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;

import com.android.volley.AuthFailureError;
import com.android.volley.DefaultRetryPolicy;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.VolleyLog;
import com.android.volley.toolbox.StringRequest;
import com.example.thefort.databinding.FragmentRegisterBinding;
import com.example.thefort.network.URLGenerator;
import com.example.thefort.network.VolleyCallBack;
import com.example.thefort.network.VolleySingleton;
import com.example.thefort.ui.UIComponents;
import com.google.android.material.snackbar.Snackbar;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.UnsupportedEncodingException;

public class RegisterFragment extends Fragment implements URLGenerator {

    UIComponents uiComponents;
    RequestQueue requestQueue;
    private String serverResponseCode;
    StringRequest stringRequest;
    private FragmentRegisterBinding binding;

    @Override
    public View onCreateView(
            LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState
    ) {

        binding = FragmentRegisterBinding.inflate(inflater, container, false);
        return binding.getRoot();

    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        uiComponents = new UIComponents(getActivity());
        binding.btnSignUp.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {


                    requestQueue = VolleySingleton.getVolleyInstance(getContext()).getRequestQueue();
                    try {
                        POSTRegisterRequest(new VolleyCallBack() {
                            @Override
                            public void OnSuccess() {


                                if (serverResponseCode != null) {

                                    switch(serverResponseCode){
                                        case "Registration successful.":
                                            Log.e("RESPONSE CODE 200: ", serverResponseCode);
                                            Snackbar.make(getActivity().findViewById(android.R.id.content),
                                                    "Successfully registered, please sign in", Snackbar.LENGTH_LONG).show();
                                            break;

                                        case "Error: Bad Request":
                                            uiComponents.alertDialog_DefaultNoCancel("Email already exist, please try another email", "Sign up Failed", "OK");
                                            binding.txtEmailEditor.setText("");
                                            binding.txtEmailEditor.requestFocus();
                                            binding.txtEmail.setError("Enter new email");
                                            binding.txtEmail.setErrorEnabled(true);
                                            break;

                                        default:
                                            uiComponents.alertDialog_DefaultNoCancel("Server is temporarily down. Please try again later", "Error", "Ok");
                                            break;

                                    }


                                }
                                serverResponseCode = null;



                            }
                        });
                    } catch (JSONException e) {
                        e.printStackTrace();
                    }




//                NavHostFragment.findNavController(RegisterFragment.this)
//                        .navigate(R.id.action_SecondFragment_to_FirstFragment);
            }
        });
    }


    public void POSTRegisterRequest(final VolleyCallBack callBack) throws JSONException {




        JSONObject jsonBody = new JSONObject();

        jsonBody.put("user_FirstName", binding.txtFNameEditor.getText());
        jsonBody.put("user_LastName", binding.txtSurnameEditor.getText());
        jsonBody.put("user_Email", binding.txtEmailEditor.getText());
        jsonBody.put("user_Password", binding.txtPasswordEditor.getText());
        jsonBody.put("user_Contact","012356789");
        jsonBody.put("user_Type","client");
        final String mRequestBody = jsonBody.toString();

        StringRequest stringRequest = new StringRequest(Request.Method.POST, generateURL(), new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                String jsonObj = response.toString();

                Log.e("VOLLEYRESPONSE", "onResponse: "+response);

                if (jsonObj.contains("Registration successful.")) {
                    serverResponseCode = getResources().getString(R.string.response_success);
                    Toast.makeText(getContext(), "Successfully registered, you may login", Toast.LENGTH_SHORT).show();

                } {
                    serverResponseCode = response.toString();
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

           /* @Override
            protected Response<String> parseNetworkResponse(NetworkResponse response) {
                String responseString = "";
                if (response != null) {
                    responseString = String.valueOf(response.statusCode);
                }
                return Response.success(responseString, HttpHeaderParser.parseCacheHeaders(response));
            }*/
        };

        stringRequest.setRetryPolicy(new DefaultRetryPolicy(3000, 3, DefaultRetryPolicy.DEFAULT_BACKOFF_MULT));

        requestQueue.add(stringRequest);
    }


    @Override
    public String generateURL() {
        return getResources().getString(R.string.WCF_URL)+"/api/Users/Register/register";
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }

}