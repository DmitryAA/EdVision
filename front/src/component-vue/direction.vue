<template>
	<div class="b-direction row">
		<div v-if="info" class="b-direction__info">
			<h1>{{info.Name}}</h1>
		</div>
		<div v-if="info" class="b-direction__students">
			<h2>Интересующися студенты</h2>
			<section v-for="item in info.Students">
				<article>
					<router-link :to="{ path: '/student/' + item.Id}">{{item.LastName}} {{item.FirstName}} {{item.PatronimicName}}</router-link>
				</article>
			</section>
		</div>
	</div>
</template>

<script>
	import axios from 'axios';

	export default {
		name: 'direction',
		data() {
			return {
				info: null
			};
		},
		mounted() {
			axios
				.get('http://192.168.0.30:1488/api/educationdirections/' + this.$route.params.id)
				.then(response => (this.info = response.data));
		}
	};
</script>
