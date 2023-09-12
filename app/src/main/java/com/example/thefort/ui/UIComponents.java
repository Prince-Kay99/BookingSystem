package com.example.thefort.ui;

import android.app.Activity;
import android.app.DatePickerDialog;
import android.content.DialogInterface;
import android.content.SharedPreferences;
import android.util.Log;
import android.view.View;
import android.view.ViewGroup;

import androidx.appcompat.app.AlertDialog;
import androidx.recyclerview.widget.LinearLayoutManager;

import com.example.thefort.R;

public class UIComponents {

    private final Activity myActivity;
    public UIComponents(Activity mActivity){
        this.myActivity = mActivity;
    }

    public void alertDialog_DefaultNoCancel(String msg, String title, String OKBtn) {
        AlertDialog.Builder dialog=new AlertDialog.Builder(myActivity);
        dialog.setMessage(msg);
        dialog.setTitle(title);
        dialog.setPositiveButton(OKBtn,
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog,
                                        int which) {
                    }
                });
        AlertDialog alertDialog=dialog.create();
        alertDialog.show();
    }

    public boolean alertDialog_deleteAccount(String msg, String title, String OKBtn, String CancelBtn) {
        AlertDialog.Builder dialog=new AlertDialog.Builder(myActivity);
        String m = "Yes";
        dialog.setMessage(msg);
        dialog.setTitle(title);
        dialog.setPositiveButton(OKBtn,
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog,
                                        int which) {
                        /**
                         * TODO: make a delete account functionality
                         */


                    }
                });
        dialog.setNegativeButton(CancelBtn, new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {

            }
        });
        AlertDialog alertDialog=dialog.create();
        alertDialog.show();
        return false;
    }

    public void disableLayoutAndChildren(ViewGroup layout, boolean enable) {
        for (int i = 0; i < layout.getChildCount(); i++) {
            View child = layout.getChildAt(i);
            child.setEnabled(enable);
            if (child instanceof ViewGroup) {
                ViewGroup group = (ViewGroup) child;
                for (int j = 0; j < group.getChildCount(); j++) {
                    group.getChildAt(j).setEnabled(enable);
                    group.getChildAt(j).setClickable(enable);
                }
            }

        }
    }

    public void clearStoredPreferences(SharedPreferences sp, String string) {
      //  SharedPreferences settings = getSharedPreferences(YOUR_PREFS_NAME, 0);
        SharedPreferences.Editor editor = sp.edit();
        editor.clear().apply();

    }


}
