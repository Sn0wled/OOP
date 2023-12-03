#pragma once
#include <iostream>

using namespace std;

template <class T>
class NodeT {
public:
	string key;
	T val;
	NodeT* next;
	NodeT() : key(""), val(), next(0) {}
	NodeT(string& key, T& val) : key(key), val(val), next(0) {}
	NodeT(string& key, T& val, NodeT* next) : NodeT(key, val), next(next) {}
	NodeT(const NodeT& N) : key(N.key), val(N.val), next(0) {}
};

template <class T>
class ddict
{
	typedef NodeT<T> Node;
	Node* root;
public:
	ddict() : root(NULL) {}
	~ddict();

	ddict(const ddict& d);
	ddict& operator=(const ddict& d);

	ddict& subdictK(int (*pred)(string&)) const;
	ddict& subdictV(int (*pred)(T&)) const;
	void add(const string&, const T&);
	void del(const string&);
	ddict operator+(const ddict&) const;
	ddict operator-(const ddict&) const;
	int count();
	void clear();
	T& operator[](string n);

	friend ostream& operator<<(ostream& os, const ddict& d) {
		Node* tmp = d.root;
		while (tmp != NULL)
		{
			os << tmp->key << ": " << tmp->val << endl;
			tmp = tmp->next;
		}
		return os;
	}
};