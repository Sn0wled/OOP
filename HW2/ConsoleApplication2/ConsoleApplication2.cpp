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
	a.add("asd", 123);
	a.add("sdf", 234);
	ddict<int> b = a.subdictK([a = "asd"](string s){return a < s; });
	ddict<int> c = a.subdictV([d = 123](int s) {return s > d; });
}
