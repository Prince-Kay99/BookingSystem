package com.example.thefort.adapters;

import android.content.Context;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentPagerAdapter;
import androidx.lifecycle.Lifecycle;
import androidx.viewpager2.adapter.FragmentStateAdapter;

import com.example.thefort.LoginFragment;
import com.example.thefort.RegisterFragment;

public class LoginAdapter extends FragmentPagerAdapter{

    private Context context;
    private int totTabs;

    public LoginAdapter(@NonNull FragmentManager fm, Context myContext, int totalTabs) {
        super(fm);
        this.context=myContext;
        this.totTabs=totalTabs;


    }


    @NonNull
    @Override
    public Fragment getItem(int position) {
        switch (position){
            case 0:
                LoginFragment loginFragment = new LoginFragment();

                return loginFragment;
            case 1:
                RegisterFragment registerFragment = new RegisterFragment();
                return registerFragment;
            default:
                return null;

        }

    }


    @Override
    public int getCount() {
        return totTabs;
    }


}
