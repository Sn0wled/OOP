/* 2018 ReVoL Primer Template */
// main.cpp
// тема: 
#include "class.h"

int main() {
    /*intVector iv1;
    intVector iv2(10);
    intVector iv3(iv2);
    cout << "max_size = " << iv1.max_size() << endl;
    cout << "max_size = " << iv2.max_size() << endl;
    cout << "capacity = " << iv1.capacity() << endl;
    cout << "capacity = " << iv2.capacity() << endl;
    iv1.reserve(10);
    cout << "capacity = " << iv1.capacity() << endl;
    cout << "size     = " << iv1.size()     << endl;
    iv1.resize(20);
    cout << "capacity = " << iv1.capacity() << endl;
    cout << "size     = " << iv1.size() << endl;
    for (int i = 0; i < (int)iv2.size(); i++) {
        iv2[i] = i * 5;
    }
    try {
        int x = iv2.at(100);
    }
    catch (out_of_range) {
        cout << "Exception" << endl;
    }
    cout << "front = " << iv2.front() << endl;
    cout << "back  = " << iv2.back() << endl;

    int j = 1;
    intVector::iterator itor;
    for (itor = iv2.begin(); itor != iv2.end(); itor++) {
        *itor = j++;
        cout << "element = " << *itor << endl;
    }
    intVector::const_reverse_iterator rit;
    for (rit = iv2.rbegin(); rit < iv2.rend(); rit++) {
        cout << "element = " << *rit << endl;
    }

    cout << "\nadd one\n\n";
    itor = iv2.insert(iv2.begin() + 5, 11);
    cout << "current = " << *itor << endl;
    showiv(iv2);

    cout << "\nadd five\n\n";
    iv2.insert(iv2.begin() + 6, 5, 12);
    showiv(iv2);

    cout << "\nerase five\n\n";
    iv2.erase(iv2.begin() + 6, iv2.begin() + 11);
    showiv(iv2);

    cout << "\nerase one\n\n";
    iv2.erase(iv2.begin() + 5);
    showiv(iv2);

    cout << "\ninsert from\n\n";
    intVector iv4(10, 50);
    iv2.insert(iv2.begin() + 5, iv4.begin(), iv4.begin() + 5);
    showiv(iv2);

    cout << "\npush-back\n\n";
    iv2.push_back(100);
    showiv(iv2);
    
    cout << "\npop-back\n\n";
    iv2.pop_back();
    showiv(iv2);

    cout << "\nclear\n\n";
    iv2.clear();
    showiv(iv2);*/

    /*intVector iv1(5), iv2(5);
    for (int i = 0; i < 5; i++) {
        iv1[i] = iv2[i] = i * 5;
    }
    showiv(iv1);
    showiv(iv2);
    if (iv1 == iv2) cout << "\nequal\n\n";

    iv2.push_back(25);
    if (iv1 < iv2) cout << "\niv1 < iv2\n\n";

    cout << "\nswap and compare\n\n";
    iv1.swap(iv2);
    iv1[1] = 0;
    showiv(iv1);
    showiv(iv2);
    if (iv1 < iv2) cout << "\niv1 < iv2\n\n";
    return 0;*/

    intList L1(5), L2(5, 1);
    lister it;
    int i = 0;
    for (it = L1.begin(); it != L1.end(); it++) { *it = i++ * 5; }
    i = 0;
    for (it = L2.begin(); it != L2.end(); it++) { *it = i++; }
    showil(L1);
    showil(L2);
    cout << "\n splice\n\n";
    L1.splice(++L1.begin(), L2, ++(++L2.begin()), --L2.end());
    showil(L1);
    showil(L2);
    cout << "\n front\n\n";
    L1.pop_front();
    showil(L1);
    L1.push_front(1);
    showil(L1);
    cout << "\n merge\n\n";
    L1.merge(L2);
    showil(L1);
    cout << "\n reverse\n\n";
    L1.reverse();
    showil(L1);
    cout << "\n sort\n\n";
    *(++(++L1.begin())) = 8;
    cout << "before:" << endl;
    showil(L1);
    L1.sort();
    cout << "after:" << endl;
    showil(L1);
}
