/* 2018 ReVoL Primer Template */
// main.cpp
// тема: 
#include "class.h"

int main() {
    //lamp a;
    //colorlamp b;
    //cola c;
    //int x = 0;
    ///*cout << sizeof(b) << endl;
    //cout << *((int*)&b + 0) << endl;
    //cout << *((int*)&b + 1) << endl;
    //cout << sizeof(c) << endl;
    //cout << *((int*)&c + 0) << endl;
    //cout << *((int*)&c + 1) << endl;*/

    ///*cout << "a.get = " << a.get() << endl;
    //a.set(0);
    //cout << "a.get = " << a.get() << endl;
    //cout << "c.get = " << c.get() << endl;
    //c.set(0);
    //cout << "c.get = " << c.get() << endl;*/

    //lamp *g[] = { &c, &a };
    //g[0]->set(5);
    //g[1]->set(6);
    //cout << "g[0]->get() = " << g[0]->get() << endl;
    //cout << "g[1]->get() = " << g[1]->get() << endl;

    garland g;
    g.add(new lamp);
    g.add(new lamp);
    g.add(new cola);
    g.add(new cola);
    g.set(0);
    g.show();
    g.set(1);
    g.show();
    return 0;
}
