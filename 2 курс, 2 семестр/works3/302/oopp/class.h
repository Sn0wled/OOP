/* 2018 ReVoL Primer Template */
/* class.h */
#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <assert.h>
#include <stdio.h>
#include <math.h>
#include <string.h>
#include <iostream>
#include <vector>
#include <list>
#include <deque>
#include <map>
#include <string>
#include <functional>
#include <algorithm>
using namespace std;

typedef vector<int> intVector;
typedef list<int> intList;
typedef intList::iterator lister;
typedef deque<int> intDeque;

void showiv(intVector v) {
	cout << " size     = " << v.size() << endl;
	cout << " capacity = " << v.capacity() << endl;
	int j = 0;
	intVector::const_iterator i;
	for (i = v.begin(); i != v.end(); i++) {
		cout << "element " << j++ << " = " << *i << endl;
	}
}

int vector1() {
    intVector iv1;
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
    showiv(iv2);
    return 0;
}

int vector2() {
    intVector iv1(5), iv2(5);
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
    return 0;
}

void showil(intList v) {
	cout << "size = " << v.size() << endl;
	int j = 0;
	intList::const_iterator i;
	for (i = v.begin(); i != v.end(); i++) {
		cout << "element " << j++ << " = " << *i << endl;
	}
}

int list1() {
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
    showil(L2);
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
    cout << "\n merge sorted\n\n";
    for (int i = 0; i < 5; i++) L2.push_back(i);
    L1.merge(L2);
    showil(L1);
    return 0;
}

int pred(int i) {
    return i > 1;
}

int list2() {
    intList L1(0);
    L1.push_back(1);
    L1.push_back(1);
    L1.push_back(1);
    L1.push_back(2);
    L1.push_back(3);
    L1.push_back(3);
    L1.push_back(1);
    showil(L1);
    L1.remove(3);
    showil(L1);
    L1.unique();
    showil(L1);
    cout << "\n pred\n\n";
    L1.remove_if(pred);
    showil(L1);
    return 0;
}

int deque1() {
    intDeque id;
    for (int i = 0; i < 5; i++) {
        id.push_front(i);
        id.push_back(i);
    }
    intDeque::iterator it;
    for (it = id.begin(); it != id.end(); it++) {
        cout << "element = " << *it << endl;
    }
    for (int i = 0; i < 5; i++) id.pop_front();
    cout << "\n";
    for (it = id.begin(); it != id.end(); it++) {
        cout << "element = " << *it << endl;
    }
    return 0;
}

class product {
	string _name;
	int _price;
public:
	product(string name = "", int price = 0) {
		_name = name;
		_price = price;
	}
	int price() {
		return _price;
	}
	string name() {
		return _name;
	}
	friend ostream& operator<<(ostream& os, product p) {
		os << "product " << p.name() << "\tprice " << p.price() << endl;
		return os;
	}
};

int map1() {
    product pen("pen", 10);
    product ball("ball", 20);
    product gum("gum", 15);
    map<string, product> pmap;
    pmap[pen.name()] = pen;
    pmap[ball.name()] = ball;
    pmap[gum.name()] = gum;
    cout << "size = " << pmap.size() << endl;
    cout << "pen price = " << pmap["pen"].price() << endl;
    map<string, product>::iterator it;
    for (it = pmap.begin(); it != pmap.end(); it++) {
        cout << it->first << "\t" << it->second;
    }
    cout << "count pen = " << pmap.count("pen") << endl;
    cout << "find pen = " << pmap.find("pen")->second;
    it = pmap.lower_bound("ball");
    cout << "lower-bound ball = " << it->second;
    it = pmap.upper_bound("ball");
    cout << "upper-bound ball = " << it->second;
    it = pmap.find("com");
    if (it != pmap.end()) cout << "found\n";
    cout << "\n insert\n\n";
    product table("table", 99);
    pair<string, product> tab("table", table);
    pair<map<string, product>::iterator, bool> p = pmap.insert(tab);
    if (p.second) cout << "added table\n";
    else cout << "insert failed\n";
    pmap.erase("table");
    return 0;
}

template <class T>
class Print : public unary_function<T, void> {
public:
    void operator() (T& arg) {
        cout << arg << " ";
    }
};

template <class T>
class Greater : public unary_function<T, int> {
public:
    int operator() (T& arg) {
        return (arg > 2);
    }
};