package com.example.thefort.adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.thefort.R;
import com.example.thefort.objects.SlotObject;
import com.example.thefort.ui.IRecyclerViewClickHandler;

import java.util.ArrayList;

public class SlotsAdapter extends RecyclerView.Adapter<SlotsAdapter.ViewHolder>{

    private final ArrayList<SlotObject> localDataSet;
    private final IRecyclerViewClickHandler recyclerViewClickHandler;
    Context mContext;

    public static class ViewHolder extends RecyclerView.ViewHolder {
        private final TextView txtAvailability;
        private final TextView txtStartTime;


        public ViewHolder(View view, IRecyclerViewClickHandler recyclerViewClickHandler) {
            super(view);
            // Define click listener for the ViewHolder's View

            view.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    if(recyclerViewClickHandler!=null){
                        int pos = getAdapterPosition();

                        if(pos!= RecyclerView.NO_POSITION){
                            recyclerViewClickHandler.onItemClick(pos);
                        }

                    }
                }
            });

            txtAvailability = (TextView) view.findViewById(R.id.txtSlotAvailability);
            txtStartTime = (TextView) view.findViewById(R.id.txtSlotStartEndTime);


        }

        public TextView getTextAvailability() {
            return txtAvailability;
        }
        public TextView getTextDuration() {
            return txtStartTime;
        }



    }


    public SlotsAdapter(ArrayList<SlotObject> dataSet,Context context , IRecyclerViewClickHandler clickHandler) {
        this.recyclerViewClickHandler=clickHandler;
        this.localDataSet = dataSet;
        this.mContext=context;
    }

    // Create new views (invoked by the layout manager)
    @NonNull
    @Override
    public SlotsAdapter.ViewHolder onCreateViewHolder(ViewGroup viewGroup, int viewType) {
        // Create a new view, which defines the UI of the list item
        View view = LayoutInflater.from(viewGroup.getContext())
                .inflate(R.layout.coach_slots_content_holder, viewGroup, false);

        return new SlotsAdapter.ViewHolder(view,recyclerViewClickHandler);
    }


    @Override
    public void onBindViewHolder(SlotsAdapter.ViewHolder viewHolder, final int position) {

        viewHolder.getTextAvailability().setText( localDataSet.get(position).getBooked());
        viewHolder.getTextDuration().setText(localDataSet.get(position).getStartTime()+" - "+localDataSet.get(position).getEndTime());
    }


    @Override
    public int getItemCount() { return localDataSet.size(); }




}
