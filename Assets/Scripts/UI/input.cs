using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//description: handles user input and stores data
//NOTE: Not thoroughly tested may contain minor bugs (alert Zachary if bug found)
public class input
{

    public class key
    {
        public float weight;
        public string name;
        public bool tap;

        public key(string name)
        {
            weight = 0;
            tap = false;
            this.name = name;
        }

        public void update(){
            float press = Input.GetAxis(name);
            if (weight == 0){
                if(press!=0){
                    tap = true;
                }
                else{
                    tap = false;
                }
            }
            if(weight!=0){
                tap = false;
            }
            weight = press;
        }
    }
    public key[] keys;
    public key horizontal;
    public key vertical;
    public key jump;
    public key mousex;
    public key mousey;
    public key shift;

    public  input(){
        horizontal = new key("Horizontal");
        vertical = new key("Vertical");
        jump = new key("Jump");
        mousex = new key("Mouse X");
        mousey = new key("Mouse Y");
        shift = new key("Fire3");
    }

    public void update()
    {
        horizontal.update();
        vertical.update();
        jump.update();
        mousex.update();
        mousey.update();
        shift.update();
    }
}
