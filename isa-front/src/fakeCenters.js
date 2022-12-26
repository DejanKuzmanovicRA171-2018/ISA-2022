const centers = [
  {
    _id: "1",
    name: "Dom Zdravlja Sladjanov mali",
    location: "Zrenjain",
    address: "Njegoseva 31",
    rating: "5"
    
  },
  {
    _id: "2",
    name: "Specijalisticka ustanova Dzej",
    location: "Beograd",
    address: "Dusana Svilara 11",
    rating: "4"

  },
  {
    _id: "3",
    name: "Porodiliste za mlade Viktor Obradovic",
    location: "Novi Sad",
    address: "Kisacka 14",
    rating: "3"
  },
  {
    _id: "4",
    name: "Centar za davanje krvi A",
    location: "Subotica",
    address: "Partizanska 11",
    rating: "5"
  },
  {
    _id: "5",
    name: "Centar za davanje krvi B",
    location: "Novi Pazar",
    address: "Radnicka 16A",
    rating: "3"
  },
  {
    _id: "6",
    name: "Centar za davanje krvi C",
    location: "Zrenjanin",
    address: "Travnicka 4",
    rating: "5"
  },
  {
    _id: "7",
    name: "Centar za davanje krvi D",
    location: "Apatin",
    address: "Jevrejska 15",
    rating: "4"
  },
];

export function getCenters() {
  return centers;
}

export function getCenter(id) {
  return centers.find(m => m._id === id);
}

export function saveCenter(center) {
  let centerInDb = centers.find(m => m._id === center._id) || {};
  centerInDb.name = center.name;
  centerInDb.location = center.location;
  centerInDb.address = center.address;
  centerInDb.rating = center.rating;

  if (!centerInDb._id) {
    centerInDb._id = Date.now().toString();
    centers.push(centerInDb);
  }

  return centerInDb;
}

export function deleteCenter(id) {
  let centerInDb = centers.find(m => m._id === id);
  centers.splice(centers.indexOf(centerInDb), 1);
  return centerInDb;
}