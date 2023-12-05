#include <iostream>
#include "ddict.h"

using namespace std;

typedef ddict<int>::pair ipair;
typedef ddict<int>::Node inode;
typedef ddict<int>::iterator iiter;

int predicat(string s) {
	return s == "asd";
}

int bbb(int b) {
	return b;
}

void asd(int(*aaa)(int), int c) {
	cout << aaa(c);
}

int main() {
	ddict<int> a;
	for (int i = 0; i < 10; i++) {
		a.add(to_string(i), i);
	}
	ddict<int> b, c;
	for (int i = 5; i < 15; i++) {
		b.add(to_string(i), i);
	}
	cout << "a:" << endl << a << endl;
	cout << "b:" << endl << b << endl;
	cout << "c:" << endl << c << endl;
	c = a.subdictK([](string s) {return stoi(s) > 5; });
	cout << "subdictK:" << endl << c << endl;
	c = a.subdictV([](int s) {return s % 2 == 0; });
	cout << "subdictV:" << endl << c << endl;
	cout << "a + b :" << endl << a + b << endl;
	cout << "a - b :" << endl << a - b << endl;
	cout << "a:" << endl << a << endl;
	a.del("3");
	cout << "del(\"3\")" << endl << a << endl;
	cout << "a[\"4\"]: " << a["4"] << endl;
}
