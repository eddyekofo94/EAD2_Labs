package com.example.eddyekofo.androidlab

import android.content.Context
import android.content.Intent
import android.support.v7.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.Toast
import kotlinx.android.synthetic.main.activity_main.*

class MainActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        tempConvert.setOnClickListener {
            goToConverterPage(it)
        }


//        Call the toast function
        toastMyName()

    }

    private fun toastMyName() {
        Log.d("TAG", getString(R.string.logcatFunction))
        val myName = getString(R.string.greeting) + " " + getString(R.string.my_name)
        Toast.makeText(this, myName, Toast.LENGTH_LONG).show()
    }

    private fun goToConverterPage(view: View) {
        val intent = Intent(this, TemperatureConverter::class.java)
        startActivity(intent)
    }
}
