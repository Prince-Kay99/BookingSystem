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
import com.example.thefort.objects.TrainerObject;
import com.example.thefort.ui.IRecyclerViewClickHandler;

import java.util.ArrayList;

public class TrainerAdapter  extends RecyclerView.Adapter<TrainerAdapter.ViewHolder> {

    private final ArrayList<TrainerObject> localDataSet;
    private final IRecyclerViewClickHandler recyclerViewClickHandler;
    Context mContext;


    /**
     * Provide a reference to the type of views that you are using
     * (custom ViewHolder).
     */
    public static class ViewHolder extends RecyclerView.ViewHolder {
        private final TextView txtName;
        private final TextView txtSummary;

        private final TextView txtBookNow;

        private final TextView txtPrice;
        private final ImageView imgTrainer;

        public ViewHolder(View view, IRecyclerViewClickHandler recyclerViewClickHandler) {
            super(view);
            // Define click listener for the ViewHolder's View

            view.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    if(recyclerViewClickHandler!=null){
//                        int pos = getBindingAdapterPosition();
                       int pos = getAdapterPosition();

                        if(pos!= RecyclerView.NO_POSITION){
                            recyclerViewClickHandler.onItemClick(pos);
                        }

                    }
                }
            });

            imgTrainer = (ImageView) view.findViewById(R.id.imgTrainer);
            txtName = (TextView) view.findViewById(R.id.txtName);
            txtPrice = (TextView) view.findViewById(R.id.txtPrice);
            txtSummary = (TextView) view.findViewById(R.id.txtDescription);
            txtBookNow = (TextView) view.findViewById(R.id.txtBookNow);


        }

        public ImageView getImageTrainer() {
            return imgTrainer;
        }
        public TextView getTextName() {
            return txtName;
        }
        public TextView getTextPrice() {
            return txtPrice;
        }
        public TextView getTextSummary() {
            return txtSummary;
        }
        public TextView getTextBookNow() {
            return txtBookNow;
        }


    }


    public TrainerAdapter(ArrayList<TrainerObject> dataSet,Context context , IRecyclerViewClickHandler clickHandler) {
        this.recyclerViewClickHandler=clickHandler;
        this.localDataSet = dataSet;
        this.mContext=context;
    }


    // Create new views (invoked by the layout manager)
    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(ViewGroup viewGroup, int viewType) {
        // Create a new view, which defines the UI of the list item
        View view = LayoutInflater.from(viewGroup.getContext())
                .inflate(R.layout.trainer_content_holder, viewGroup, false);

        return new ViewHolder(view,recyclerViewClickHandler);
    }


    // Replace the contents of a view (invoked by the layout manager)
    @Override
    public void onBindViewHolder(ViewHolder viewHolder, final int position) {

        // Get element from your dataset at this position and replace the
        // contents of the view with that element

        TrainerObject trainerObject = new TrainerObject(1,"hlu","35","This the discription","logo.jpg");

        localDataSet.add(trainerObject);
        localDataSet.add(trainerObject);
        localDataSet.add(trainerObject);
        localDataSet.add(trainerObject);
        localDataSet.add(trainerObject);
        localDataSet.add(trainerObject);

        String imageName = localDataSet.get(position).getImage();
        String result = imageName.substring(0, imageName.indexOf("."));
        int drawableId = mContext.getResources().getIdentifier(result, "drawable", mContext.getPackageName());
        viewHolder.getImageTrainer().setImageResource(drawableId);
        viewHolder.getTextName().setText( localDataSet.get(position).getName());
        viewHolder.getTextPrice().setText("R" + localDataSet.get(position).getPrice());
        viewHolder.getTextSummary().setText( localDataSet.get(position).getDescription());

        viewHolder.getTextBookNow().setText("BOOK NOW");
    }


    @Override
    public int getItemCount() { return localDataSet.size(); }


}
