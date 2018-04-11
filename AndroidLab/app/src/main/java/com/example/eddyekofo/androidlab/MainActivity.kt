package com.example.eddyekofo.androidlab

import android.content.Context
import android.support.v7.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.widget.Toast

class MainActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

//        Call the toast function
        toastMyName()

    }

    private fun toastMyName() {
        Log.d("TAG", getString(R.string.logcatFunction) )
        val myName = getString(R.string.greeting) + " " + getString(R.string.my_name)
        Toast.makeText(this, myName, Toast.LENGTH_LONG).show()
    }
}
