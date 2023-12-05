#pragma once
#include <string>

using namespace std;

template <class T>
class ddict {
public:
	class Node;
	class pair;
	class iterator;
private:
	Node* root;
	Node* n_end;
public:
	ddict() :root(NULL), n_end(NULL) {}
	ddict(const ddict& d) : root(0), n_end(0) {
		Node* tmp = d.root;
		while (tmp != NULL) {
			add(tmp->p);
			tmp = tmp->next;
		}
	}
	~ddict() {
		clear();
	}
	void add(string key, T value) {
		iterator it = begin();
		for (; it != end(); it++) {
			if (it.cur->p.key == key) break;
		}
		Node* tmp = it.cur;
		if (tmp == NULL) {
			if (root == NULL) {
				root = n_end = new Node(key, value);
				return;
			}
			n_end->next = new Node(key, value);
			n_end->next->prev = n_end;
			n_end = n_end->next;
		} else {
			tmp->p.value = value;
		}
	}
	void add(pair p) {
		add(p.key, p.value);
	}
	void del(string key) {
		iterator it = begin();
		for (; it != end(); it++) {
			if ((*it).key == key) break;
		}
		Node* tmp = it.cur;
		if (tmp != NULL) {
			if (tmp->prev == NULL) {
				root = tmp->next;
			} else {
				tmp->prev->next = tmp->next;
			}
			if (tmp->next == NULL) {
				n_end = n_end->prev;
			} else {
				tmp->next->prev = tmp->prev;
			}
			delete tmp;
		}
	}
	void clear() {
		if (root != NULL) {
			Node* tmp1 = root, * tmp2 = tmp1->next;
			while (tmp2 != NULL)
			{
				delete tmp1;
				tmp1 = tmp2;
				tmp2 = tmp2->next;
			}
			delete tmp1;
			root = NULL;
			n_end = NULL;
		}
	}
	ddict subdictK(int (*pred)(string)) {
		ddict result;
		for (pair p : *this) {
			if (pred(p.key)) result.add(p);
		}
		return result;
	}
	template <class Pred>
	ddict subdictK(Pred pred) {
		ddict result;
		for (pair p : *this) {
			if (pred(p.key)) result.add(p);
		}
		return result;
	}
	ddict subdictV(int (*pred)(T)) {
		ddict result;
		for (pair p : *this) {
			if (pred(p.value)) result.add(p);
		}
		return result;
	}
	template <class Pred>
	ddict subdictV(Pred pred) {
		ddict result;
		for (pair p : *this) {
			if (pred(p.value)) result.add(p);
		}
		return result;
	}
	ddict operator+(ddict& d) {
		ddict result(*this);
		for (pair p : d) {
			result.add(p);
		}
		return result;
	}
	ddict operator-(ddict& d) {
		ddict result(*this);
		for (pair p : d) {
			result.del(p.key);
		}
		return result;
	}
	T& operator[](string key) {
		for (pair& p : *this) {
			if (p.key == key) return p.value;
		}
		throw "Ключ отсутствует";
	}
	iterator begin() {
		return iterator(root, root);
	}
	iterator end() {
		return iterator(NULL, root);
	}
	ddict& operator=(const ddict& d) {
		ddict tmp(d);
		swap(tmp.root, this->root);
		swap(tmp.n_end, this->n_end);
		return *this;
	}
	friend ostream& operator<<(ostream& os, ddict<T>& d) {
		if (d.root == NULL) {
			os << "Dictionary is empty" << endl;
			return os;
		}
		for (pair p : d) {
			os << p.key << " : " << p.value << endl;
		}
		return os;
	}
	friend ostream& operator<<(ostream& os, ddict<T>&& d) {
		if (d.root == NULL) {
			os << "Dictionary is empty" << endl;
			return os;
		}
		for (pair p : d) {
			os << p.key << " : " << p.value << endl;
		}
		return os;
	}
};

template <class T>
class ddict<T>::pair {
public:
	string key;
	T value;
	pair(string key, T value) : key(key), value(value) {}
	pair(const pair& p) : pair(p.key, p.value) {}
	//pair(const char* key, T value) : key(key), value(value) {}
};

template <class T>
class ddict<T>::iterator {
	Node* cur, * root;
public:
	iterator(Node* cur, Node* root) : cur(cur), root(root) {}
	iterator& operator++() {
		if (cur == NULL) throw "Низзя";
		cur = cur->next;
		return *this;
	}
	iterator operator++(int) {
		if (cur == NULL) throw "Низзя";
		iterator temp(*this);
		cur = cur->next;
		return temp;
	}
	iterator& operator--() {
		if (cur == root) throw "Низзя 2";
		cur = cur->prev;
		return *this;
	}
	iterator operator--(int) {
		if (cur == root) throw "Низзя 2";
		iterator temp(*this);
		cur = cur->prev;
		return temp;
	}
	pair& operator*() {
		return cur->p;
	}
	int operator!=(iterator second) {
		return cur != second.cur;
	}
	friend class ddict;
};

template <class T>
class ddict<T>::Node {
public:
	pair p;
	Node* next, * prev;
	Node(pair p) : p(p), next(0), prev(0) {}
	Node(string key, T value) : Node(pair(key, value)) {}
	Node(const Node& n) : Node(n.p) {}
};