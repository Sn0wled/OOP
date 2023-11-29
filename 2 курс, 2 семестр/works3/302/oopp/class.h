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
using namespace std;

typedef vector<int> intVector;
typedef list<int> intList;
typedef intList::iterator lister;

void showiv(intVector v) {
	cout << " size     = " << v.size() << endl;
	cout << " capacity = " << v.capacity() << endl;
	int j = 0;
	intVector::const_iterator i;
	for (i = v.begin(); i != v.end(); i++) {
		cout << "element " << j++ << " = " << *i << endl;
	}
}

void showil(intList v) {
	cout << "size = " << v.size() << endl;
	int j = 0;
	intList::const_iterator i;
	for (i = v.begin(); i != v.end(); i++) {
		cout << "element " << j++ << " = " << *i << endl;
	}
}