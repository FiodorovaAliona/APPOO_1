#include "stdafx.h"
#include "Header.h"
#include <iostream>
#include <functional>
#include <algorithm>
#include <string>
#include <map>
#include <list>
using namespace std;
//predicata TRUE if mnimoe cislo=0
bool isReal(Header &a) {
	return !(a.getImg() != 0);
}

void func1() {
	//sozdaem conteiner map
	map <string, long> m;
	for (int i = 0; i < 5; i++) {
		string key; long x;
		cout <<"Enter key: ";
		cin >> key;
		cout << "Enter value: ";
		cin >> x;
		m.insert(pair < string, long>(key, x));
	}
	//prosmotr konteiner
	for (auto e : m) {
		cout << e.first << " " << e.second << endl;
	}
	//izmenenie map
	map <string, long> ::iterator itr;
	cout << "Erasing first and changing last";
	m.erase(m.begin());

	//zamena znacenieav pervom elemente
	m.begin()->second = 777;
	itr = m.begin();
	cout << endl;
	while (itr != m.end()) {
		cout << itr->first << " : " << itr->second << endl;
		itr++;
	}
	//sozdanie novogo konteinera 
	map <string, long> mnew;
	for (int i = 0; i < 3; i++) {
		string key; long x;
		cout << "Enter key: ";
		cin >> key;
		cout << "Enter value: ";
		cin >> x;
		mnew.insert(pair < string, long>(key, x));
	}
	//udaleaem element i izmen
	cout << "Erasing elements after 2" << endl;
	itr = ++++m.begin();
	m.erase(itr, m.end());
	m.insert(mnew.begin(),mnew.end());

	//prosmotr konteiner
	cout << "Map1:" << endl;
	for (auto e : m) {
		cout << e.first << " " << e.second << endl;
	}
	cout << "Map2:" << endl;
	for (auto e : mnew) {
		cout << e.first << " " << e.second << endl;
	}
}

void func2() {
	//sozdaem conteiner map
	map <string, Header> m;
	for (int i = 0; i < 5; i++) {
		string key;
		Header a;
		cout << "Enter key: ";
		cin >> key;
		cin >> a;
		m.insert(pair < string, Header>(key, a));
	}
	cout << endl;
	//prosmotr konteiner
	for (auto e : m) {
		cout << e.first << " " << e.second << endl;
	}
	cout << endl;
	//izmenenie map
	map <string, Header> ::iterator itr;
	cout << "Erasing first and changing last" << endl;
	m.erase(m.begin());

	//zamena znacenieav pervom elemente
	Header b;
	cout << "Enter new values : " << endl;
	cin >> b;
	m.begin()->second = b;
	itr = m.begin();
	cout << endl;
	while (itr != m.end()) {
		cout << itr->first << " : " << itr->second << endl;
		itr++;
	}
	cout << endl;

	//sozdanie novogo konteinera 
	map <string, Header> mnew;
	for (int i = 0; i < 3; i++) {
		string key;
		Header a;
		cout << "Enter key: ";
		cin >> key;
		cin >> a;
		mnew.insert(pair < string, Header>(key, a));
	}
	cout << endl;
	//udaleaem element i izmen
	cout << "Erasing elements after 2" << endl;
	itr = ++++m.begin();
	m.erase(itr, m.end());
	m.insert(mnew.begin(), mnew.end());
	cout << endl;
	//prosmotr konteiner
	cout << "Map1:" << endl;
	for (auto e : m) {
		cout << e.first << " " << e.second << endl;
	}
	cout << endl;
	cout << "Map2:" << endl;
	for (auto e : mnew) {
		cout << e.first << " " << e.second << endl;
	}
}

void func3() {
	//sozdaem conteiner map
	map <string, Header> m;
	for (int i = 0; i < 5; i++) {
		string key;
		Header a;
		cout << "Enter key: ";
		cin >> key;
		cin >> a;
		m.insert(pair < string, Header>(key, a));
	}
	cout << endl;
	//sortiruem po umolceaniu
	

	//prosmotr konteiner
	cout << "First conteiner: " << endl;
	for (auto e : m) {
		cout << e.first << " " << e.second << endl;
	}
	cout << endl;
	
	//
	// poisk elementa po usloviu
	map<string, Header>::iterator itr;
	itr = find_if(m.begin(), m.end(), [](const pair<string, Header>& a) {
		return a.second.getImg() == 0; });
	cout << "\n Deistvitelinoe chislo: " << itr->second << endl;

	//новый контейнер
	list <Header> l;
	for(auto e : m) {
		if (isReal(e.second)) {
			l.push_back(e.second);
		}
	}
	
	//prosmotr 2 conteinera
	cout << "Second conteiner: " << endl;
	list<Header>::iterator litr;
	litr = l.begin();
	while (litr!=l.end()){
		cout << *litr << endl;
		litr++;
	}
	//sort list povozrastaniu
	l.sort();   // отсортировали список по возрастанию

	cout << "First conteiner: " << endl;
	for (auto e : m) {
		cout << e.second << endl;
	}
	cout << endl << "Second conteiner: " << endl;
	for (auto e : l) {
		cout << e << endl;
	}
	//slieanie dvuh conteinerov
	list<Header> newlist;
	for (auto e : m) {
		newlist.push_back(e.second);
	}
	for (auto e : l) {
		newlist.push_back(e);
	}
	//prosmotr
	cout << endl << "Third conteiner: " << endl;
	for (auto e : newlist) {
		cout << e << endl;
	}
	//prosmotr udvoletvorenia uslovia
	int counter = count_if(newlist.begin(), newlist.end(), isReal);
	cout << "Udovletvoriaet usloviu " << counter << " elementov" << endl;

	// poisk elementa po usloviu
	list<Header>::iterator itrlist;
	itrlist = find_if(newlist.begin(), newlist.end(), isReal);
	cout << "\n Deistvitelinoe chislo: " << *itrlist << endl;

}
int main()
{
	//func1();
	//func2();
	func3();
	system("pause");
    return 0;
}

