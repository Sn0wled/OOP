#include "ddict.h"

template <class T>
ddict<T>::~ddict() {
	/*if (root != NULL) {
		Node* tmp = root->next;
		while (tmp != NULL)
		{
			delete root;
			root = tmp;
			tmp = root->next;
		}
		delete root;
	}*/
	clear();
}

template <class T>
ddict<T>::ddict(const ddict& d) : ddict() {
	if (d.root != NULL) {
		Node* tmp = d.root;
		root = new Node(tmp->key, tmp->val);
		tmp = tmp->next;
		Node* ptr = root;
		while (tmp != NULL) {
			ptr->next = new Node(tmp->key, tmp->val);
			tmp = tmp->next;
			ptr = ptr->next;
		}
	}
}

template <class T>
ddict<T>& ddict<T>::operator=(const ddict& d) {
	ddict tmp(d);
	swap(root, tmp.root);
	return *this;
}

template <class T>
ddict<T>& ddict<T>::subdictK(int (*pred)(string&)) const {
	Node* tmp = root;
	ddict result;
	while (tmp != NULL) {
		if (pred(tmp->key)) add(tmp->key, tmp->val);
		tmp = tmp->next;
	}
	return result;
}

template <class T> 
ddict<T>& ddict<T>::subdictV(int(*pred)(T&)) const {
	Node* tmp = root;
	ddict result;
	while (tmp != NULL) {
		if (pred(tmp->val)) add(tmp->key, tmp->val);
		tmp = tmp->next;
	}
	return result;
}

template <class T>
void ddict<T>::add(const string& n_key, const T& n_val) {
	this->operator[](n_key) = n_val;
}

template <class T>
void ddict<T>::del(const string& d_key) {
	if (root != NULL) {
		if (root->next == NULL) {
			if (root->key == d_key) {
				delete root;
				root = NULL;
			}
		}
		else {
			if (root->key == d_key) {
				Node* tmp = root->next;
				delete root;
				root = tmp;
			}
			else {
				Node* ptr1 = root, * ptr2 = root->next;
				while (ptr2 != NULL && ptr2->key != d_key) {
					ptr1 = ptr2;
					ptr2 = ptr2->next;
				}
				if (ptr2 != NULL) {
					ptr1->next = ptr2->next;
					delete ptr2;
				}
			}
		}
	}
}

template <class T>
ddict<T> ddict<T>::operator+(const ddict& dict) const {
	ddict new_dict(*this);
	Node* temp = dict.root;
	while (temp != NULL) {
		new_dict.add(temp->key, temp->val);
		temp = temp->next;
	}
	return new_dict;
}

template <class T>
ddict<T> ddict<T>::operator-(const ddict& dict) const {
	ddict new_dict(*this);
	Node* temp = dict.root;
	while (temp != NULL) {
		new_dict.del(temp->key);
		temp = temp->next;
	}
	return new_dict;
}

template <class T>
int ddict<T>::count() {
	Node* tmp = root;
	int counter = 0;
	while (tmp != NULL) {
		counter++;
		tmp = tmp->next;
	}
	return counter;
}

template<class T>
void ddict<T>::clear() {
	if (root != NULL) {
		Node* tmp = root->next;
		while (tmp != NULL)
		{
			delete root;
			root = tmp;
			tmp = root->next;
		}
		delete root;
	}
	
}

template <class T>
T& ddict<T>::operator[](string n) {
	Node* tmp = root;
	while (tmp != NULL) {
		if (tmp->key == n) return tmp->val;
		tmp = tmp->next;
	}
	Node* n_node = new Node;
	n_node->next = root;
	root = n_node;
	root->key = n;
	return n_node->val;
}

