
using System;
using System.Collections.Generic;
using System.Text;

public class Single<T> where T : new () {

    private static T instance;

    public static T Instance {
        get {
            if (instance == null) instance = new T();
            return instance;
        }
    }

}

