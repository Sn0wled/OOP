/* 2018 ReVoL Primer Template */
// main.cpp
// тема: 
#include "class.h"

int main() {
    Print<int> print;
    vector<int> v(5);
    typedef vector<int>::iterator itor;
    for (int i = 0; i < 5; i++) v[i] = i;
    itor first = v.begin();
    itor last = v.end();
    cout << "\n for-each\n\n";
    for_each(first, last, print);
    cout << "\n\n find-if\n\n";
    Greater<int> preg;
    itor r = find_if(first, last, preg);
    if (r != last) cout << "find_if = " << *r << endl;
}
