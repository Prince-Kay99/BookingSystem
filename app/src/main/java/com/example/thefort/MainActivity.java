package com.example.thefort;

import android.os.Bundle;

import com.example.thefort.adapters.LoginAdapter;
import com.google.android.material.color.DynamicColors;
import com.google.android.material.snackbar.Snackbar;

import androidx.appcompat.app.AppCompatActivity;

import android.view.View;

import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.core.view.WindowCompat;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.ui.AppBarConfiguration;
import androidx.navigation.ui.NavigationUI;
import androidx.viewpager.widget.ViewPager;

import com.example.thefort.databinding.ActivityMainBinding;
import com.google.android.material.tabs.TabLayout;

import android.view.Menu;
import android.view.MenuItem;

public class MainActivity extends AppCompatActivity {

    private AppBarConfiguration appBarConfiguration;
    private ActivityMainBinding binding;
    TabLayout mTabLayout;
    ViewPager mViewPager;
    ConstraintLayout mLoginCOnstraintLayout;
    float v=0;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        DynamicColors.applyToActivitiesIfAvailable(getApplication());
        binding = ActivityMainBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());



        binding.tabLayout.addTab(binding.tabLayout.newTab().setText("Login"));
        binding.tabLayout.addTab(binding.tabLayout.newTab().setText("Sign Up"));
        binding.tabLayout.setTabGravity(TabLayout.GRAVITY_FILL);

        final LoginAdapter fragmentAdapterLogin = new LoginAdapter(getSupportFragmentManager()
                ,this,binding.tabLayout.getTabCount());
        binding.viewPager.setAdapter(fragmentAdapterLogin);

        binding.viewPager.addOnPageChangeListener(new TabLayout.TabLayoutOnPageChangeListener(binding.tabLayout));



        animateView();
    }


    private void animateView(){

        binding.tabLayout.setTranslationY(300);
        binding.tabLayout.setAlpha(v);



        binding.tabLayout.animate().translationY(0).alpha(1).setDuration(1000).setStartDelay(100).start();
        mLoginCOnstraintLayout = (ConstraintLayout) findViewById(R.id.layout_activityLogin);
        mTabLayout = (TabLayout) findViewById(R.id.tabLayout);
        mViewPager = (ViewPager) findViewById(R.id.viewPager);

    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.bottom_nav_menu, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
//        if (id == R.id.action_LoginFragment_to_RegisterFragment) {
//            return true;
//        }

        return super.onOptionsItemSelected(item);
    }

    @Override
    public boolean onSupportNavigateUp() {
        NavController navController = Navigation.findNavController(this, R.id.nav_host_fragment_content_main);
        return NavigationUI.navigateUp(navController, appBarConfiguration)
                || super.onSupportNavigateUp();
    }
}